using ApiDigitalLesson.BL.Services.Impl;
using ApiDigitalLesson.Identity.Models.Entity;

namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Интерфейс работы с сервисом <see cref="UserIdentityService"/>
    /// </summary>
    public interface IUserIdentityService
    {
        /// <summary>
        /// Получить текущего пользователя
        /// </summary>
        Task<UserIdentity> GetCurrentUserAsync();

        /// <summary>
        /// Получить пользователя по email
        /// </summary>
        Task<UserIdentity> GetUserForEmailAsync(string email);

        /// <summary>
        /// Получить пользователя по Id
        /// </summary>
        Task<UserIdentity> GetUserForIdAsync(string id);

        /// <summary>
        /// Получить роль текущего пользователя
        /// </summary>
        Task<string?> GetRoleCurrentUserAsync();

        /// <summary>
        /// Получить роль по Id пользователя
        /// </summary>
        Task<string> GetRoleUserAsync(string userId);
    }
}