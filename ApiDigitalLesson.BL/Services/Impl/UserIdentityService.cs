using System.Security.Claims;
using ApiDigitalLesson.BL.Services.Interface;
using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Identity.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ApiDigitalLesson.BL.Services.Impl
{
    /// <summary>
    /// Базовый сервис для получения пользователя
    /// </summary>
    public class UserIdentityService : IUserIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly ILogger<UserIdentityService> _logger;

        public UserIdentityService(
            IHttpContextAccessor httpContextAccessor, 
            UserManager<UserIdentity> userManager, 
            ILogger<UserIdentityService> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _logger = logger;
        }

        /// <summary>
        /// Получить текущего пользователя
        /// </summary>
        public async Task<UserIdentity> GetCurrentUserAsync()
        {
            try
            {
                var identity = _httpContextAccessor.HttpContext?.User;

                if (identity == null)
                {
                    throw new Exception("Не удалось найти контекст пользователя");
                }
                
                var email = identity.FindFirst(ClaimTypes.Email)?.Value;
                
                if (email.IsNull())
                {
                    throw new Exception("Не удалось найти Email пользователя");
                }

                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    throw new Exception("Не удалось найти пользователя по данному email");
                }

                return user;
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить текущего пользователя, {e.Message}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить пользователя по email
        /// </summary>
        public async Task<UserIdentity> GetUserForEmailAsync(string email)
        {
            try
            {
                if (email.IsNull())
                {
                    throw new Exception("Email не может быть пустым");
                }

                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    throw new Exception("Не удалось найти пользователя по данному email");
                }

                return user;
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить пользователя по email, {e.Message}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
        
        /// <summary>
        /// Получить пользователя по Id
        /// </summary>
        public async Task<UserIdentity> GetUserForIdAsync(string id)
        {
            try
            {
                if (id.IsNull())
                {
                    throw new Exception("Id не может быть пустым");
                }

                var user = await _userManager.FindByIdAsync(id);

                if (user == null)
                {
                    throw new Exception("Не удалось найти пользователя по данному Id");
                }

                return user;
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить пользователя по id, {e.Message}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить роль текущего пользователя
        /// </summary>
        public async Task<string?> GetRoleCurrentUserAsync()
        {
            try
            {
                var user = await GetCurrentUserAsync();

                var roles = await _userManager.GetRolesAsync(user);
                
                var role = roles.First();

                if (role == null || role.IsNull())
                {
                    throw new Exception("Не удалось найти роль пользователя");
                }

                return role;
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить роль текущего пользователя, {e.Message}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Получить роль по Id пользователя
        /// </summary>
        public async Task<string> GetRoleUserAsync(string userId)
        {
            try
            {
                if (userId.IsNull())
                {
                    throw new Exception("Id не может быть пустым");
                }

                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    throw new Exception("Не удалось найти пользователя по данному Id");
                }

                var role = await _userManager.GetRolesAsync(user);

                var result = role.First();

                if (result == null || result.IsNull())
                {
                    throw new Exception("Не удалось найти роль пользователя");
                }

                return result;
            }
            catch (Exception e)
            {
                var message = $"Не удалось получить роль текущего пользователя, {e.Message}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
    }
}
