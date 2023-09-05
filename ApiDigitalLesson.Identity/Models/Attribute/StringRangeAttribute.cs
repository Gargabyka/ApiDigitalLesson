using System.ComponentModel.DataAnnotations;
using ApiDigitalLesson.Model.Const;

namespace ApiDigitalLesson.Identity.Models.Attribute
{
    public class StringRangeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if(value.ToString() == Roles.Student || value.ToString() == Roles.Teacher)
            {
                return ValidationResult.Success;
            }


            return new ValidationResult("Введена неправильная роль");
        }
    }
}