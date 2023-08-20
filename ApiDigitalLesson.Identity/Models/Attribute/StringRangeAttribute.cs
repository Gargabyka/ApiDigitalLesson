using System.ComponentModel.DataAnnotations;
using AspDigitalLesson.Model.Enums;

namespace ApiDigitalLesson.Identity.Models.Attribute
{
    public class StringRangeAttribute : ValidationAttribute
    
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if(value.ToString() == Roles.Student.ToString() || value.ToString() == Roles.Teacher.ToString())
            {
                return ValidationResult.Success;
            }


            return new ValidationResult("Введена неправильная роль");
        }
    }
}