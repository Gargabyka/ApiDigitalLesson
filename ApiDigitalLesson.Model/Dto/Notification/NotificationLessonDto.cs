using ApiDigitalLesson.Model.Enums;

namespace ApiDigitalLesson.Model.Dto.Notification
{
    /// <summary>
    /// DTO информации о занятии
    /// </summary>
    public class NotificationLessonDto
    {
        /// <summary>
        /// Id занятия
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Id пользователя
        /// </summary>
        public string UserId { get; set; }
        
        /// <summary>
        /// Тип занятия
        /// </summary>
        public LessonEnum LessonEnum { get; set; }
        
        /// <summary>
        /// Уведомления
        /// </summary>
        public NotificationSend NotificationSend { get; set; }
    }
}