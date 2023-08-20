using System.ComponentModel.DataAnnotations;
using AspDigitalLesson.Model.Interface;

namespace AspDigitalLesson.Model.Entity
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
