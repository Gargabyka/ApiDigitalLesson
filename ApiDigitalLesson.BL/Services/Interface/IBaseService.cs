using ApiDigitalLesson.Identity.Models.Entity;

namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Базовый интерфейс для получения пользователя
    /// </summary>
    public interface IBaseService
    {
        /// <summary>
        /// Текущий пользователь
        /// </summary>
        public UserIdentity CurrentUser { get; }
    }
}
