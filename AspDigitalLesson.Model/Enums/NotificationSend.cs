namespace AspDigitalLesson.Model.Enums
{
    /// <summary>
    /// Enum типов уведомлений
    /// </summary>
    public enum NotificationSend
    {
        /// <summary>
        /// Запрос на занятие
        /// </summary>
        RequestLesson = 0,
        
        /// <summary>
        /// Подтверждение занятия
        /// </summary>
        AcceptLesson = 1,
        
        /// <summary>
        /// Отмененное занятие
        /// </summary>
        CancelLesson = 2,
        
        /// <summary>
        /// Скорое занятие
        /// </summary>
        ComingLesson = 3
    }
}