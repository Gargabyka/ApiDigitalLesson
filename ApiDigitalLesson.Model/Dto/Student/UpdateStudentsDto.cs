namespace ApiDigitalLesson.Model.Dto.Student
{
    /// <summary>
    /// Dto обновления студента
    /// </summary>
    public class UpdateStudentsDto
    {
        /// <summary>
        /// Телефон
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Телеграмм
        /// </summary>
        public long? TelegramId { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }
    }
}