namespace ApiDigitalLesson.Identity.Models.Request
{
    /// <summary>
    /// Запрос email
    /// </summary>
    public class EmailRequest
    {
        /// <summary>
        /// Кому
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Тема
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Тело
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// От кого
        /// </summary>
        public string From { get; set; }
    }
}
