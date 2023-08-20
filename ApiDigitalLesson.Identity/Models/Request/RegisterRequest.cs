using System.ComponentModel.DataAnnotations;
using ApiDigitalLesson.Identity.Models.Attribute;

namespace ApiDigitalLesson.Identity.Models.Request
{
    /// <summary>
    /// Запрос регистрации
    /// </summary>
    public class RegisterRequest
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
        
        [Required]
        [StringRange]
        public string Role { get; set; }
    }
}
