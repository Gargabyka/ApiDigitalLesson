using System.ComponentModel.DataAnnotations;

namespace ApiDigitalLesson.Identity.Models.Request
{
    /// <summary>
    /// Запрос забытого пароля
    /// </summary>
    public class ForgotPasswordRequest
    {
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
