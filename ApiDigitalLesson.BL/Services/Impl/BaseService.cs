using System.Security.Claims;
using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Identity.Exception;
using ApiDigitalLesson.Identity.Models.Entity;
using Microsoft.AspNetCore.Identity;

namespace ApiDigitalLesson.BL.Services.Impl
{
    /// <summary>
    /// Базовый сервис для получения пользователя
    /// </summary>
    public class BaseService : IBaseService
    {
        private readonly ClaimsPrincipal _userPrincipal;
        
        protected readonly UserManager<UserIdentity> UserManager;

        protected BaseService(ClaimsPrincipal userPrincipal, UserManager<UserIdentity> userManager)
        {
            _userPrincipal = userPrincipal;
            UserManager = userManager;
        }

        /// <summary>
        /// Текущий пользователь
        /// </summary>
        public UserIdentity CurrentUser
        {
            get
            {
                var userEmail = _userPrincipal.FindFirst(ClaimTypes.Email)?.Value;

                if (userEmail != null && userEmail.IsNull())
                {
                    throw new ApiException("Не удалось найти email пользователя");
                }

                var user = UserManager.FindByEmailAsync(userEmail).Result;

                return  user ?? throw new ApiException("Не удалось найти пользователя");
            }
        }

    }
}
