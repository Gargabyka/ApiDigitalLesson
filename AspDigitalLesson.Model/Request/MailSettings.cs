namespace ApiDigitalLesson.Identity.Models.Request
{
    /// <summary>
    /// Настройки подключения к Email
    /// </summary>
    public class MailSettings
    {
        /// <summary>
        /// От кого
        /// </summary>
        public string EmailFrom { get; set; }
        
        /// <summary>
        /// Имя отправителя
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// Smtp сервис
        /// </summary>
        public string SmtpHost { get; set; }

        /// <summary>
        /// Smtp пользователь
        /// </summary>
        public string SmtpUser { get; set; }

        /// <summary>
        /// Smtp пароль
        /// </summary>
        public string SmtpPass { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Smtp порт
        /// </summary>
        public int SmtpPort { get; set; }
    }
}
