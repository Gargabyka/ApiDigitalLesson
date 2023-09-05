using ApiDigitalLesson.BL.Services.Impl;
using ApiDigitalLesson.Model.Dto;
using ApiDigitalLesson.Model.Dto.Notification;

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
        Task SendNotification(NotificationLessonDto notificationLesson);
    }
}