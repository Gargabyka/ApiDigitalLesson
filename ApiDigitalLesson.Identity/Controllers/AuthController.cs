using System.Net;
using System.Security.Claims;
using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Identity.Models.Dto;
using ApiDigitalLesson.Identity.Models.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.Identity.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController: Controller
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly ILogger<AuthController> _logger;

        public AuthController(UserManager<UserIdentity> userManager, ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult VkLogin()
        {
            return Challenge(new AuthenticationProperties {RedirectUri = new PathString("/api/Auth/OAuthCallback") }, "Vkontakte");
        }

        [HttpGet]
        public IActionResult GoogleLogin()
        {
            return Challenge(new AuthenticationProperties {RedirectUri = new PathString("/api/Auth/OAuthCallback") }, "Google");
        }
        
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> OAuthCallback()
        {
            var tempAuth = await HttpContext.AuthenticateAsync("Vkontakte");
            var authResult = tempAuth.Succeeded ? tempAuth : await HttpContext.AuthenticateAsync("Google");

            if (!authResult.Succeeded)
            {
                return Unauthorized();
            }
            
            var claimInfo = new OAuthClaimInfoDto
            {
                Id = authResult.Principal.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                Name = authResult.Principal.FindFirst(ClaimTypes.GivenName)?.Value,
                Surname = authResult.Principal.FindFirst(ClaimTypes.Surname)?.Value,
                Email = authResult.Principal.FindFirst(ClaimTypes.Email)?.Value
            };

            var redirect = await GetRedirect(claimInfo);
            
            return Redirect(redirect);
        }

        /// <summary>
        /// Получить дальнейший редирект
        /// </summary>
        private async Task<string> GetRedirect(OAuthClaimInfoDto claimInfoDto)
        {
            try
            {
                var swagger = "https://localhost:7285/swagger/index.html";
                //TODO:Добавить перенаправление на ui
                var uri = $"{Request.Scheme}://{Request.Host.Value}";

                if (claimInfoDto.Email == null && claimInfoDto.Id == null)
                {
                    return swagger;
                }

                var user = await _userManager.FindByEmailAsync(claimInfoDto.Email) ??
                           await _userManager.FindByNameAsync(claimInfoDto.Id);

                if (user != null)
                {
                    //TODO: редирект на получение данных пользователя
                    return swagger;
                }

                //TODO:Редирект на создание пользователя
                return swagger;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}