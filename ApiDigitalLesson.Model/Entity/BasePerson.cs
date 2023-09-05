namespace ApiDigitalLesson.Model.Entity
{
    public class BasePerson : BaseEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Телеграмм
        /// </summary>
        public long? TelegramId { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? DateBirthday { get; set; }

        /// <summary>
        /// Id пользователя 
        /// </summary>
        public Guid UserId { get; set; }
    }
}