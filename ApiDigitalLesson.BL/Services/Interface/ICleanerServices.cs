using ApiDigitalLesson.BL.Services.Impl;

namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Интерфейс сервиса <see cref="CleanerServices"/>
    /// </summary>
    public interface ICleanerServices
    {
        /// <summary>
        /// Отчистить старые данные из бд
        /// </summary>
        public Task CleanAsync(int mount);
    }
}