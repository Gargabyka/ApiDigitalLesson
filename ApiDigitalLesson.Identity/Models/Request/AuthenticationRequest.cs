using System.ComponentModel.DataAnnotations;

namespace ApiDigitalLesson.Identity.Models.Request
{
    /// <summary>
    /// Запрос аутентификации
    /// </summary>
    public class AuthenticationRequest
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
