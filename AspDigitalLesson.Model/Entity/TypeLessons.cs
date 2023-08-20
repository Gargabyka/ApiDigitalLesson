using System.ComponentModel.DataAnnotations.Schema;

namespace AspDigitalLesson.Model.Entity
{
    /// <summary>
    /// Тип занятия
    /// </summary>
    public class TypeLessons: BaseEntity
    {
        /// <summary>
        /// Название занятия
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание занятие
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Категория
        /// </summary>
        public int? Category{ get; set; }
        
        /// <summary>
        /// Родитель
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Родитель
        /// </summary>
        public TypeLessons? Parent { get; set; }
        
        /// <summary>
        /// Дочерние категории
        /// </summary>
        public ICollection<TypeLessons> SubCategories { get; set; }
    }
}
