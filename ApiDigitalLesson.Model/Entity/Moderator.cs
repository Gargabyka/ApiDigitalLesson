namespace ApiDigitalLesson.Model.Entity
{
    /// <summary>
    /// Сущность модератор
    /// </summary>
    public class Moderator : BaseEntity
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
        /// Дата рождения
        /// </summary>
        public DateTime? DateBirthday { get; set; }

        /// <summary>
        /// Id пользователя 
        /// </summary>
        public Guid UserId { get; set; }
        
        /// <summary>
        /// Удален
        /// </summary>
        public bool IsDelete { get; set; }
    }
}