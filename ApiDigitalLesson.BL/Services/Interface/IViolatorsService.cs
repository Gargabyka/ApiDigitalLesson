using ApiDigitalLesson.BL.Services.Impl;
using ApiDigitalLesson.Common.Model;
using AspDigitalLesson.Model.Dto;

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
    }
}