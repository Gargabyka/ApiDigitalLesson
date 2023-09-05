using ApiDigitalLesson.BL.Services.Impl;
using ApiDigitalLesson.Common.Model;
using ApiDigitalLesson.Model.Dto;
using ApiDigitalLesson.Model.Dto.Violators;

namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Интерфейс сервиса <see cref="ViolatorsService"/>
    /// </summary>
    public interface IViolatorsService
    {
        /// <summary>
        /// Получить список нарушений
        /// </summary>
        Task<BaseResponse<List<ViolatorsDto>>> GetViolatorsListAsync();

        /// <summary>
        /// Создание жалобы 
        /// </summary>
        Task<Guid> CreateViolatorAsync(ViolatorsDto violatorsDto);

        /// <summary>
        /// Бан нарушителя
        /// </summary>
        Task BannedViolatorsAsync(string id, DateTime dateBan);

        /// <summary>
        /// Отмена жалобы пользователя
        /// </summary>
        Task CancelViolatorsAsync(string id);

        /// <summary>
        /// Проверка пользователя на бан
        /// </summary>
        Task<bool> IsBannedAsync(string? teacherId, string? studentId);

        /// <summary>
        /// Проверка текущего пользователя на бан
        /// </summary>
        Task<bool> IsBannedCurrentUserAsync();

        /// <summary>
        /// Разбан нарушителя
        /// </summary>
        Task UnbanViolatorsAsync(string id);
    }
}