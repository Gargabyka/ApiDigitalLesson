using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using ApiDigitalLesson.Common.CustomException;
using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Common.Services;
using ApiDigitalLesson.Common.Services.Interface.SMTP;
using ApiDigitalLesson.Identity.Models.Dto;
using ApiDigitalLesson.Identity.Models.Entity;
using ApiDigitalLesson.Identity.Models.Enums;
using ApiDigitalLesson.Identity.Models.Request;
using ApiDigitalLesson.Identity.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ApiDigitalLesson.Identity.Services.Impl
{
    /// <summary>
    /// Класс для работы с аккаунтами пользователей
    /// </summary>
    public class AccountService: IAccountService
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly RoleManager<RoleIdentity> _roleManager;
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly ILogger<AccountService> _logger;
        private readonly JwtSettings _jwtSettings;
        private readonly IEmailService _emailService;
        public AccountService(
            UserManager<UserIdentity> userManager,
            RoleManager<RoleIdentity> roleManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<UserIdentity> signInManager,
            IEmailService emailService, 
            ILogger<AccountService> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
            _emailService = emailService;
            _logger = logger;
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        public async Task<BaseResponse<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string uri)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email.Trim()) ??
                           await _userManager.FindByNameAsync(request.UserName.Trim());

                if (user == null)
                {
                    throw new ApiException("Пользователь не найден")
                        { StatusCode = (int)HttpStatusCode.BadRequest };
                }

                if (!user.EmailConfirmed)
                {
                    var verificationUri = await SendVerificationEmail(user, uri);
                    throw new ApiException($"Данный email не подтвержден.Пожалуйста, подтвердите свой аккаунт перейдя по данной ссылке: {verificationUri}")
                        { StatusCode = (int)HttpStatusCode.BadRequest };
                }

                var signUser = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
                if (!signUser.Succeeded)
                {
                    throw new ApiException("Введен неверный пароль")
                        { StatusCode = (int)HttpStatusCode.BadRequest };
                }

                var ip = IpHelper.GetIpAddress();
                if (ip.IsNull())
                {
                    throw new ApiException("Не удалось получить Ip адрес")
                        { StatusCode = (int)HttpStatusCode.BadRequest };
                }

                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.First();
                if (role.IsNull())
                {
                    throw new ApiException("Не удалось получить роль пользователя")
                        { StatusCode = (int)HttpStatusCode.BadRequest };
                }

                var jwToken = await GenerateJwToken(user, ip);
                var response = new AuthenticationResponse()
                {
                    Id = user.Id,
                    JWToken = new JwtSecurityTokenHandler().WriteToken(jwToken),
                    Email = user.Email,
                    UserName = user.UserName,
                    Roles = role,
                    IsVerified = user.EmailConfirmed,
                    RefreshToken = await GenerateRefreshToken(user)
                };
                return new BaseResponse<AuthenticationResponse>(response, $"Аутентификация {user.UserName}");
            }
            catch (System.Exception e)
            {
                var message = $"Не удалось провести авторизацию пользователя, {e.InnerException}";
                _logger.LogError(message);
                throw new System.Exception(message);
            }
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        public async Task<BaseResponse<string>> RegisterAsync(RegisterRequest request, string uri)
        {
            try
            {
                var userFind = await _userManager.FindByEmailAsync(request.Email);
                if (userFind != null)
                {
                    throw new ApiException($"Пользователь под '{request.Email}' уже зарегистрирован.") { StatusCode = (int)HttpStatusCode.BadRequest };
                }

                var user = new UserIdentity()
                {
                    Email = request.Email,
                    UserName = request.UserName,
                };

                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, request.Role);
                    //return new BaseResponse<string>("Пользователь успешно зарегистрирован!");

                    var verificationUri = await SendVerificationEmail(user, uri);

                    return new BaseResponse<string>(user.Id, message: $"Пользователь зарегистрирован. Пожалуйста, подтвердите свой аккаунт перейдя по данной ссылке: {verificationUri}");
                }

                return new BaseResponse<string>("Произошла ошибка при регистрации пользователя") {Succeeded = false};
            }
            catch (System.Exception e)
            {
                var message = $"Не удалось зарегистрировать пользователя, {e.InnerException}";
                _logger.LogError(message);
                throw new System.Exception(message);
            }
        }

        /// <summary>
        /// Подтвердить email адрес
        /// </summary>
        public async Task<BaseResponse<string>> ConfirmEmailAsync(string userId, string code)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
                var result = await _userManager.ConfirmEmailAsync(user, code);
                if (result.Succeeded)
                {
                    return new BaseResponse<string>(user.Id, message: $"Данный пользователь успешно подтвержден {user.Email}.");
                }

                throw new ApiException($"Произошла ошибка при подтверждении аккаунта {user.Email}.") { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
            catch (System.Exception e)
            {
                var message = $"Не удалось подтвердить email пользователя, {e.InnerException}";
                _logger.LogError(message);
                throw new System.Exception(message);
            }
        }

        /// <summary>
        /// Запрос на сброс пароля
        /// </summary>
        public async Task ForgotPasswordAsync(ForgotPasswordRequest request, string uri)
        {
            try
            {
                const string route = "api/Identity/reset-password/";
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null) return;

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var enpointUri = new Uri(string.Concat($"{uri}/", route));
                var resetPasswordUri = QueryHelpers.AddQueryString(enpointUri.ToString(), "userId", user.Id);
                var emailRequest = new EmailRequest()
                {
                    Body = $"Для сброса пароля перейдите по ссылке:",
                    ToName = user.UserName,
                    ToAddress = request.Email,
                    Subject = "Сброс пароля",
                    Link = resetPasswordUri
                };
                await _emailService.PostAsync(emailRequest);
            }
            catch (System.Exception e)
            {
                var message = $"Не удалось сбросить пароль пользователя, {e.InnerException}";
                _logger.LogError(message);
                throw new System.Exception(message);
            }
        }

        /// <summary>
        /// Восстановление пароля
        /// </summary>
        public async Task<BaseResponse<string>> ResetPasswordAsync(string userId, ResetPasswordRequest request)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null) throw new ApiException($"Пользователь под данным не зарегистрирован.");

                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, resetToken, request.Password);
                if (result.Succeeded)
                {
                    return new BaseResponse<string>(user.Email, message: $"Пароль восстановлен.");
                }

                throw new ApiException($"Произошла ошибка при восстановлении пароля. Пожалуйста повторите попытку.");
            }
            catch (System.Exception e)
            {
                var message = $"Не удалось восстановить пароль пользователя, {e.InnerException}";
                _logger.LogError(message);
                throw new System.Exception(message);
            }
        }

        /// <summary>
        /// Обновить токен
        /// </summary>
        public async Task<BaseResponse<AuthenticationResponse>> RefreshTokenAsync(RefreshTokenRequest request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                {
                    throw new ApiException($"Нет зарегистрированного пользователя под данным email:'{request.Email}'.") { StatusCode = (int)HttpStatusCode.BadRequest };
                }
                if (!user.EmailConfirmed)
                {
                    throw new ApiException($"Аккаунт под данным email:'{request.Email}' не подтвержден.") { StatusCode = (int)HttpStatusCode.BadRequest };
                }

                var refreshToken = await _userManager.GetAuthenticationTokenAsync(user, "MyApp", "RefreshToken");
                var isValid = await _userManager.VerifyUserTokenAsync(user, "MyApp", "RefreshToken", request.Token);
                if (!refreshToken.Equals(request.Token) || !isValid)
                {
                    throw new ApiException($"Ошибка при получении токена.") { StatusCode = (int)HttpStatusCode.BadRequest };
                }

                var ipAddress = IpHelper.GetIpAddress();
                var jwtSecurityToken = await GenerateJwToken(user, ipAddress);
                var response = new AuthenticationResponse()
                {
                    Id = user.Id,
                    JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Email = user.Email,
                    UserName = user.UserName,
                    IsVerified = user.EmailConfirmed,
                    RefreshToken = await GenerateRefreshToken(user)
                };

                var role = await _userManager.GetRolesAsync(user);
            
                response.Roles = role.First();

                await _signInManager.SignInAsync(user, false);
                return new BaseResponse<AuthenticationResponse>(response, $"Аутентификация {user.UserName}");
            }
            catch (System.Exception e)
            {
                var message = $"Не удалось обновить токен пользователя, {e.InnerException}";
                _logger.LogError(message);
                throw new System.Exception(message);
            }
        }

        /// <summary>
        /// Выход из системы
        /// </summary>
        public async Task<BaseResponse<string>> LogoutAsync(string emailOrName)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(emailOrName)
                           ?? await _userManager.FindByNameAsync(emailOrName);

                if (user != null)
                {
                    await _userManager.RemoveAuthenticationTokenAsync(user, "MyApp", "RefreshToken");
                }
                await _signInManager.SignOutAsync();

                return new BaseResponse<string>(emailOrName, message: $"Logout.");
            }
            catch (System.Exception e)
            {
                var message = $"Не удалось выйти из системы, {e.InnerException}";
                _logger.LogError(message);
                throw new System.Exception(message);
            }
        }

        /// <summary>
        /// Получить пользователей
        /// </summary>
        public async Task<List<UserListDto>> GetUsers()
        {
            try
            {
                var userList = await _userManager.Users.ToListAsync();
                var userListDto = new List<UserListDto>();

                foreach (var users in userList)
                {
                    var roles = await _userManager.GetRolesAsync(users);

                    var user = new UserListDto()
                    {
                        Id = users.Id,
                        UserName = users.UserName,
                        Email = users.Email,
                        Phone = users.PhoneNumber,
                        Role = roles.First() ?? string.Empty,
                        EmailConfirmed = users.EmailConfirmed,
                        PhoneConfirmed = users.PhoneNumberConfirmed
                    };

                    userListDto.Add(user);
                }

                return userListDto;
            }
            catch (System.Exception e)
            {
                var message = $"Не удалось получить список пользователей, {e.InnerException}";
                _logger.LogError(message);
                throw new System.Exception(message);
            }
        }

        /// <summary>
        /// Сгенерировать токен
        /// </summary>
        private async Task<JwtSecurityToken> GenerateJwToken(UserIdentity user, string ip)
        {
            try
            {
                var userClaims = await _userManager.GetClaimsAsync(user);
                var roles = await _userManager.GetRolesAsync(user);

                var roleClaim = new List<Claim>()
                {
                    new Claim("role", roles.First())
                };

                var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim("uid", user.Id),
                        new Claim("ip", ip)
                    }
                    .Union(userClaims)
                    .Union(roleClaim);

                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

                var jwtSecurityToken = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                    signingCredentials: signingCredentials);
                return jwtSecurityToken;
            }
            catch (System.Exception e)
            {
                var message = $"Произошла ошибка при генерации токена, {e.InnerException}";
                _logger.LogError(message);
                throw new System.Exception(message);
            }
        }

        /// <summary>
        /// Обновить токен
        /// </summary>
        private async Task<string> GenerateRefreshToken(UserIdentity user)
        {
            try
            {
                await _userManager.RemoveAuthenticationTokenAsync(user, "MyApp", "RefreshToken");
                var newRefreshToken = await _userManager.GenerateUserTokenAsync(user, "MyApp", "RefreshToken");
                var result = await _userManager.SetAuthenticationTokenAsync(user, "MyApp", "RefreshToken", newRefreshToken);
                if (!result.Succeeded)
                {
                    throw new ApiException("Произошла ошибка при обновлении токена") { StatusCode = (int)HttpStatusCode.InternalServerError };
                }
                return newRefreshToken;
            }
            catch (System.Exception e)
            {
                var message = $"Произошла ошибка при обновлении токена, {e.InnerException}";
                _logger.LogError(message);
                throw new System.Exception(message);
            }
        }

        /// <summary>
        /// Отправить письмо с подтверждением email
        /// </summary>
        private async Task<string> SendVerificationEmail(UserIdentity user, string uri)
        {
            try
            {
                const string route = "api/Identity/confirm-email/";
            
                var verificationCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                verificationCode = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(verificationCode));
                var enpointUri = new Uri(string.Concat($"{uri}/", route));
                var verificationUri = QueryHelpers.AddQueryString(enpointUri.ToString(), "userId", user.Id.ToString());
                verificationUri = QueryHelpers.AddQueryString(verificationUri, "code", verificationCode);

                var request = new EmailRequest()
                {
                    ToName = user.UserName,
                    ToAddress = user.Email,
                    Body = $"Пожалуйста, подтвердите свой аккаунт перейдя по данной ссылке:",
                    Subject = "Подтверждение регистрации",
                    Link = verificationUri
                };
                
                await _emailService.PostAsync(request);

                return verificationUri;
            }
            catch (System.Exception e)
            {
                var message = $"Произошла ошибка при отправки письма, {e.InnerException}";
                _logger.LogError(message);
                throw new System.Exception(message);
            }
        }
    }
}
