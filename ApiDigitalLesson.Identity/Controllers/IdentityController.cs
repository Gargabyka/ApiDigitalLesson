using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Identity.Models.Dto;
using ApiDigitalLesson.Identity.Models.Request;
using ApiDigitalLesson.Identity.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        public IdentityController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            var uri = $"{Request.Scheme}://{Request.Host.Value}";
            var result = await _accountService.AuthenticateAsync(request, uri);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var uri = $"{Request.Scheme}://{Request.Host.Value}";
            var result = await _accountService.RegisterAsync(request, uri);
            return Ok(result);
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string userId, [FromQuery] string code)
        {
            return Ok(await _accountService.ConfirmEmailAsync(userId, code));
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var uri = $"{Request.Scheme}://{Request.Host.Value}";
            await _accountService.ForgotPasswordAsync(request, uri);
            return Ok();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync([FromQuery] string userId, ResetPasswordRequest request)
        {
            return Ok(await _accountService.ResetPasswordAsync(userId, request));
        }

        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequest request)
        {
            return Ok(await _accountService.RefreshTokenAsync(request));
        }

        [Authorize]
        [HttpGet("logout")]
        public async Task<IActionResult> LogoutAsync(string emailOrName)
        {
            return Ok(await _accountService.LogoutAsync(emailOrName));
        }

        [Authorize]
        [HttpGet("getuserlist")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var userList = await _accountService.GetUsers();
            return Ok(new BaseResponse<IReadOnlyList<UserListDto>>(userList));
        }

    }
}
