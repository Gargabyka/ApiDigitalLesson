using ApiDigitalLesson.BL.Services.Impl;
using AspDigitalLesson.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ApiDigitalLesson.BL.Services.Interface
{
    /// <summary>
    /// Интерфейс сервиса <see cref="NotificationService"/>
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Отправить уведомление
        /// </summary>
        Task<IActionResult> SendNotification(NotificationLessonDto notificationLesson);
    }
}