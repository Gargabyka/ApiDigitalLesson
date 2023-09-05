namespace ApiDigitalLesson.Model.Request
{
    /// <summary>
    /// Запрос email
    /// </summary>
    public class EmailRequest
    {
        /// <summary>
        /// Email получателя
        /// </summary>
        public string ToAddress { get; set; }
        
        /// <summary>
        /// Имя получателя
        /// </summary>
        public string ToName { get; set; }

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
        
        /// <summary>
        /// Имя отправителя письма
        /// </summary>
        public string Sender { get; set; }
        
        /// <summary>
        /// Ссылка
        /// </summary>
        public string Link { get; set; }
    }
}
