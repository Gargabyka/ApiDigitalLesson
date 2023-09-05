using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Identity.Models.Dto;
using ApiDigitalLesson.Identity.Models.Request;
using ApiDigitalLesson.Identity.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.Identity.Controllers
{
    /// <summary>
    /// Контроллер аутентификации 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<IdentityController> _logger;

        public IdentityController(IAccountService accountService, ILogger<IdentityController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            try
            {
                var uri = $"{Request.Scheme}://{Request.Host.Value}";
                var result = await _accountService.AuthenticateAsync(request, uri);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(IdentityController)}. " +
                    $"Произошла ошибка при работе метода AuthenticateAsync. {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            try
            {
                var uri = $"{Request.Scheme}://{Request.Host.Value}";
                var result = await _accountService.RegisterAsync(request, uri);
                return Ok(result);
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(IdentityController)}. " +
                    $"Произошла ошибка при работе метода RegisterAsync. {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string userId, [FromQuery] string code)
        {
            try
            {
                return Ok(await _accountService.ConfirmEmailAsync(userId, code));
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(IdentityController)}. " +
                    $"Произошла ошибка при работе метода ConfirmEmailAsync. {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            try
            {
                var uri = $"{Request.Scheme}://{Request.Host.Value}";
                await _accountService.ForgotPasswordAsync(request, uri);
                return Ok();
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(IdentityController)}. " +
                    $"Произошла ошибка при работе метода ForgotPasswordAsync. {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPasswordAsync([FromQuery] string userId, ResetPasswordRequest request)
        {
            try
            {
                return Ok(await _accountService.ResetPasswordAsync(userId, request));
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(IdentityController)}. " +
                    $"Произошла ошибка при работе метода ResetPasswordAsync. {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequest request)
        {
            try
            {
                return Ok(await _accountService.RefreshTokenAsync(request));
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(IdentityController)}. " +
                    $"Произошла ошибка при работе метода RefreshTokenAsync. {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [Authorize]
        [HttpGet("Logout")]
        public async Task<IActionResult> LogoutAsync(string emailOrName)
        {
            try
            {
                return Ok(await _accountService.LogoutAsync(emailOrName));
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(IdentityController)}. " +
                    $"Произошла ошибка при работе метода LogoutAsync. {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [Authorize]
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsersAsync()
        {
            try
            {
                var userList = await _accountService.GetUsers();
                return Ok(new BaseResponse<IReadOnlyList<UserListDto>>(userList));
            }
            catch (Exception e)
            {
                var message =
                    $"Контроллер: {nameof(IdentityController)}. " +
                    $"Произошла ошибка при работе метода GetUsersAsync. {e.Message}";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

    }
}
