using ApiDigitalLesson.Model.Entity;

namespace ApiDigitalLesson.Model.Dto
{
    /// <summary>
    /// Dto сущности <see cref="Students"/>
    /// </summary>
    public class StudentsDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

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
        public string Phone { get; set; }

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
        public string Description { get; set; }
        
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateBirthday { get; set; }
    }
}
