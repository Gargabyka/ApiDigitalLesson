using ApiDigitalLesson.BL.Services.Impl;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Model.Dto;
using ApiDigitalLesson.Model.Dto.Moderator;

namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Интерфейс сервиса <see cref="ModeratorService"/>
    /// </summary>
    public interface IModeratorService
    {
        /// <summary>
        /// Получить список модераторов
        /// </summary>
        Task<BaseResponse<List<ModeratorDto>>> GetModeratorListAsync();

        /// <summary>
        /// Получить модератора пользователя
        /// </summary>
        Task<BaseResponse<ModeratorDto>> GetModeratorUserAsync();
        
        /// <summary>
        /// Получить модератора по Id
        /// </summary>
        Task<BaseResponse<ModeratorDto>> GetModeratorAsync(string id);

        /// <summary>
        /// Создание модератора
        /// </summary>
        Task CreateModeratorAsync(ModeratorDto moderatorDto, string userId);

        /// <summary>
        /// Удалить модератора
        /// </summary>
        Task DeleteModeratorAsync(string id);
    }
}