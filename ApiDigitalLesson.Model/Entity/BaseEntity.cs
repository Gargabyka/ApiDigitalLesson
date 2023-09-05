using System.ComponentModel.DataAnnotations;
using ApiDigitalLesson.Model.Interface;

namespace ApiDigitalLesson.Model.Entity
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public class BaseEntity : IEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid Id { get; set; }
    }
}
