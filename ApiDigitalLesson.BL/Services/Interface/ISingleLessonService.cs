using ApiDigitalLesson.BL.Services.Impl;
using ApiDigitalLesson.Common.Model;
using AspDigitalLesson.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Интерфейс работы с сервисом <see cref="SingleLessonService"/>
    /// </summary>
    public interface ISingleLessonService
    {
        /// <summary>
        /// Получить индивидуальный урок по id
        /// </summary>
        Task<BaseResponse<SingleLessonWithScheduler>> GetSingleLessonForIdAsync(string id);

        /// <summary>
        /// Получить индивидуальные уроки преподавателя
        /// </summary>
        Task<BaseResponse<List<SingleLessonWithScheduler>>> GetSingleLessonForTeacherIdAsync(string teacherId);

        /// <summary>
        /// Создание индивидуального урока
        /// </summary>
        Task<ActionResult> CreateSingleLessonAsync(CreateSingleLessonDto data);

        /// <summary>
        /// Получить список неподтвержденных уроков пользователя
        /// </summary>
        Task<BaseResponse<List<SingleLessonWithScheduler>>> GetUnConfirmSingleLessonAsync();

        /// <summary>
        /// Подтвердить индивидуальный урок урок
        /// </summary>
        Task<IActionResult> ConfirmSingleLessonAsync(string id);

        /// <summary>
        /// Отменить индивидуальный урок
        /// </summary>
        Task<IActionResult> CancelSingleLessonAsync(string id, string description);
    }
}