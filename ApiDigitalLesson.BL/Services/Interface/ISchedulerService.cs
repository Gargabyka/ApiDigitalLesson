using ApiDigitalLesson.BL.Services.Impl;
using ApiDigitalLesson.Model.Dto;
using ApiDigitalLesson.Model.Dto.Scheduler;

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