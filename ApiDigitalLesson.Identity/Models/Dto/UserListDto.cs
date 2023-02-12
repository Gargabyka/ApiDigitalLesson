namespace ApiDigitalLesson.Identity.Models.Dto
{
    /// <summary>
    /// Список пользователей
    /// </summary>
    public class UserListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Email подтвержден
        /// </summary>
        public bool EmailConfirmed { get; set; }

        /// <summary>
        /// Телефон подтвержден
        /// </summary>
        public bool PhoneConfirmed { get; set; }
    }
}
