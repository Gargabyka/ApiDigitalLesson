using System.Security.Claims;
using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.DL.Controllers.Services.Interface;
using ApiDigitalLesson.Identity.Exception;
using ApiDigitalLesson.Identity.Models.Entity;
using Microsoft.AspNetCore.Identity;

namespace ApiDigitalLesson.DL.Controllers.Services.Impl
{
    /// <summary>
    /// Базовый сервис для получения пользователя
    /// </summary>
    public class BaseService : IBaseService
    {
        protected readonly ClaimsPrincipal _userPrincipal;
        protected readonly UserManager<UserIdentity> _userManager;

        public BaseService(ClaimsPrincipal userPrincipal, UserManager<UserIdentity> userManager)
        {
            _userPrincipal = userPrincipal;
            _userManager = userManager;
        }

        /// <summary>
        /// Текущий пользователь
        /// </summary>
        public UserIdentity CurrentUser
        {
            get
            {
                var userEmail = _userPrincipal.FindFirst(ClaimTypes.Email)?.Value;

                if (userEmail.IsNull())
                {
                    throw new ApiException("Не удалось найти email пользователя");
                }

                var user = _userManager.FindByEmailAsync(userEmail).Result;

                return  user ?? throw new ApiException("Не удалось найти пользователя");
            }
        }

    }
}
