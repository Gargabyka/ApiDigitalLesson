namespace AspDigitalLesson.Model.Dto
{
    /// <summary>
    /// Выбор отправки уведомления
    /// </summary>
    public class SelectNotificationDto
    {
        /// <summary>
        /// TelegramId
        /// </summary>
        public long? TelegramId { get; set; }
        
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }
}