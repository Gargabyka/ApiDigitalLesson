using ApiDigitalLesson.DL.Model.Interface;
using ApiDigitalLesson.Identity.Models;

namespace ApiDigitalLesson.DL.Model.Entity
{
    /// <summary>
    /// Студент
    /// </summary>
    public class Students: IEntity
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
        public string Telegram { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Discription { get; set; }

        /// <summary>
        /// Id пользователя 
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Пользователя 
        /// </summary>
        public UserIdentity User { get; set; }
    }
}
