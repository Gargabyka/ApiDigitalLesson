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

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            try
            {
                var uri = $"{Request.Scheme}://{Request.Host.Value}";
                var result = await _accountService.AuthenticateAsync(request, uri);
                return Ok(result);
            }
            catch (System.Exception e)
            {
                var message =
                    $"Контроллер: {nameof(IdentityController)}. Произошла ошибка при работе метода AuthenticateAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            try
            {
                var uri = $"{Request.Scheme}://{Request.Host.Value}";
                var result = await _accountService.RegisterAsync(request, uri);
                return Ok(result);
            }
            catch (System.Exception e)
            {
                var message =
                    $"Контроллер: {nameof(IdentityController)}. Произошла ошибка при работе метода RegisterAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string userId, [FromQuery] string code)
        {
            try
            {
                return Ok(await _accountService.ConfirmEmailAsync(userId, code));
            }
            catch (System.Exception e)
            {
                var message =
                    $"Контроллер: {nameof(IdentityController)}. Произошла ошибка при работе метода ConfirmEmailAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            try
            {
                var uri = $"{Request.Scheme}://{Request.Host.Value}";
                await _accountService.ForgotPasswordAsync(request, uri);
                return Ok();
            }
            catch (System.Exception e)
            {
                var message =
                    $"Контроллер: {nameof(IdentityController)}. Произошла ошибка при работе метода ForgotPasswordAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync([FromQuery] string userId, ResetPasswordRequest request)
        {
            try
            {
                return Ok(await _accountService.ResetPasswordAsync(userId, request));
            }
            catch (System.Exception e)
            {
                var message =
                    $"Контроллер: {nameof(IdentityController)}. Произошла ошибка при работе метода ResetPasswordAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequest request)
        {
            try
            {
                return Ok(await _accountService.RefreshTokenAsync(request));
            }
            catch (System.Exception e)
            {
                var message =
                    $"Контроллер: {nameof(IdentityController)}. Произошла ошибка при работе метода RefreshTokenAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [Authorize]
        [HttpGet("logout")]
        public async Task<IActionResult> LogoutAsync(string emailOrName)
        {
            try
            {
                return Ok(await _accountService.LogoutAsync(emailOrName));
            }
            catch (System.Exception e)
            {
                var message =
                    $"Контроллер: {nameof(IdentityController)}. Произошла ошибка при работе метода LogoutAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

        [Authorize]
        [HttpGet("getuserlist")]
        public async Task<IActionResult> GetUsersAsync()
        {
            try
            {
                var userList = await _accountService.GetUsers();
                return Ok(new BaseResponse<IReadOnlyList<UserListDto>>(userList));
            }
            catch (System.Exception e)
            {
                var message =
                    $"Контроллер: {nameof(IdentityController)}. Произошла ошибка при работе метода GetUsersAsync";
                
                _logger.LogError(e,message);
                return StatusCode(500, message);
            }
        }

    }
}
