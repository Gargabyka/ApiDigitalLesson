using System.ComponentModel.DataAnnotations;

namespace ApiDigitalLesson.Identity.Models.Request
{
    /// <summary>
    /// Запрос восстановления пароля
    /// </summary>
    public class ResetPasswordRequest
    {
        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        /// <summary>
        /// Повтор пароля
        /// </summary>
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string ConfirmPassword { get; set; }
    }
}
