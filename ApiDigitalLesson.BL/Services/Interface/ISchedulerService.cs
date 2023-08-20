using ApiDigitalLesson.BL.Services.Impl;
using AspDigitalLesson.Model.Dto;

namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Интерфейс работы с сервисом <see cref="SchedulerService"/>
    /// </summary>
    public interface ISchedulerService
    {
        /// <summary>
        /// Проверка дат на пересечение
        /// </summary>
        Task<bool> IntersectionDates(IntersectionDatesDto intersectionDates);
    }
}