using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Common.Services.Impl;
using ApiDigitalLesson.Identity.Exception;
using ApiDigitalLesson.Identity.Models.Dto;
using ApiDigitalLesson.Identity.Models.Entity;
using ApiDigitalLesson.Identity.Models.Enums;
using ApiDigitalLesson.Identity.Models.Request;
using ApiDigitalLesson.Identity.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
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
        private readonly JWTSettings _jwtSettings;
        private readonly IEmailService _emailService;
        public AccountService(UserManager<UserIdentity> userManager,
            RoleManager<RoleIdentity> roleManager,
            IOptions<JWTSettings> jwtSettings,
            SignInManager<UserIdentity> signInManager,
            IEmailService emailService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
            _emailService = emailService;
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        public async Task<BaseResponse<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string uri)
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

            var jwToken = await GenerateJWToken(user, ip);
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

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        public async Task<BaseResponse<string>> RegisterAsync(RegisterRequest request, string uri)
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
                await _userManager.AddToRoleAsync(user, Roles.Student.ToString());
                //return new BaseResponse<string>("Пользователь успешно зарегистрирован!");

                var verificationUri = await SendVerificationEmail(user, uri);

                return new BaseResponse<string>(user.Id.ToString(), message: $"Пользователь зарегистрирован. Пожалуйста, подтвердите свой аккаунт перейдя по данной ссылке: {verificationUri}");
            }

            return new BaseResponse<string>("Произошла ошибка при регистрации пользователя") {Succeeded = false};
        }

        /// <summary>
        /// Подтвердить email адрес
        /// </summary>
        public async Task<BaseResponse<string>> ConfirmEmailAsync(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return new BaseResponse<string>(user.Id.ToString(), message: $"Данный пользователь успешно подтвержден {user.Email}.");
            }

            throw new ApiException($"Произошла ошибка при подтверждении аккаунта {user.Email}.") { StatusCode = (int)HttpStatusCode.InternalServerError };
            
        }

        /// <summary>
        /// Запрос на сброс пароля
        /// </summary>
        public async Task ForgotPasswordAsync(ForgotPasswordRequest request, string uri)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) return;

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var route = "api/Identity/reset-password/";
            var enpointUri = new Uri(string.Concat($"{uri}/", route));
            var resetPasswordUri = QueryHelpers.AddQueryString(enpointUri.ToString(), "userId", user.Id.ToString());
            var emailRequest = new EmailRequest()
            {
                Body = $"Для сброса пароля перейдите по ссылке: {resetPasswordUri}",
                To = request.Email,
                Subject = "Сброс пароля",
            };
            await _emailService.SendAsync(emailRequest);
        }

        /// <summary>
        /// Восстановление пароля
        /// </summary>
        public async Task<BaseResponse<string>> ResetPasswordAsync(string userId, ResetPasswordRequest request)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new ApiException($"Пользователь под данным email:'{user.Email}' не зарегистрирован.");

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, request.Password);
            if (result.Succeeded)
            {
                return new BaseResponse<string>(user.Email, message: $"Пароль восстановлен.");
            }

            throw new ApiException($"Произошла ошибка при восстановлении пароля. Пожалуйста повторите попытку.");
            
        }

        /// <summary>
        /// Обновить токен
        /// </summary>
        public async Task<BaseResponse<AuthenticationResponse>> RefreshTokenAsync(RefreshTokenRequest request)
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

            string refreshToken = await _userManager.GetAuthenticationTokenAsync(user, "MyApp", "RefreshToken");
            bool isValid = await _userManager.VerifyUserTokenAsync(user, "MyApp", "RefreshToken", request.Token);
            if (!refreshToken.Equals(request.Token) || !isValid)
            {
                throw new ApiException($"Ошибка при получении токена.") { StatusCode = (int)HttpStatusCode.BadRequest };
            }

            string ipAddress = IpHelper.GetIpAddress();
            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user, ipAddress);
            AuthenticationResponse response = new AuthenticationResponse();
            response.Id = user.Id.ToString();
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.UserName = user.UserName;
            var role = await _userManager.GetRolesAsync(user);
            response.Roles = role.First();
            response.IsVerified = user.EmailConfirmed;
            response.RefreshToken = await GenerateRefreshToken(user);

            await _signInManager.SignInAsync(user, false);
            return new BaseResponse<AuthenticationResponse>(response, $"Аутентификация {user.UserName}");
        }

        /// <summary>
        /// Выход из системы
        /// </summary>
        public async Task<BaseResponse<string>> LogoutAsync(string emailOrName)
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

        /// <summary>
        /// Получить пользователей
        /// </summary>
        public async Task<List<UserListDto>> GetUsers()
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
                    Role = roles.First() ?? String.Empty,
                    EmailConfirmed = users.EmailConfirmed,
                    PhoneConfirmed = users.PhoneNumberConfirmed
                };

                userListDto.Add(user);
            }

            return userListDto;
        }

        /// <summary>
        /// Сгенерировать токен
        /// </summary>
        private async Task<JwtSecurityToken> GenerateJWToken(UserIdentity user, string ip)
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
                    new Claim("uid", user.Id.ToString()),
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

        /// <summary>
        /// Обновить токен
        /// </summary>
        private async Task<string> GenerateRefreshToken(UserIdentity user)
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

        /// <summary>
        /// Отправить письмо с подтверждением email
        /// </summary>
        private async Task<string> SendVerificationEmail(UserIdentity user, string uri)
        {
            var verificationCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            verificationCode = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(verificationCode));
            var route = "api/Identity/confirm-email/";
            var _enpointUri = new Uri(string.Concat($"{uri}/", route));
            var verificationUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "userId", user.Id.ToString());
            verificationUri = QueryHelpers.AddQueryString(verificationUri, "code", verificationCode);

            await _emailService.SendAsync(new EmailRequest()
            {
                To = user.Email,
                Body = $"Пожалуйста, подтвердите свой аккаунт перейдя по данной ссылке: {verificationUri}",
                Subject = "Подтверждение регистрации"
            });

            return verificationUri;
        }
    }
}
