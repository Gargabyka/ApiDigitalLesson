namespace ApiDigitalLesson.Model.Dto.Teacher
{
    /// <summary>
    /// Обновление данных о преподавателе
    /// </summary>
    public class UpdateTeacherDto
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
        
        /// <summary>
        /// Фото
        /// </summary>
        public byte[]? Photo { get; set; }
    }
}