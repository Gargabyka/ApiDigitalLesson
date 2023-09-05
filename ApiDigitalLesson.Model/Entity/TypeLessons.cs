using Newtonsoft.Json;

namespace ApiDigitalLesson.Model.Entity
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
        /// Родитель
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Родитель
        /// </summary>
        [JsonIgnore]
        public TypeLessons? Parent { get; set; }
        
        /// <summary>
        /// Дочерние категории
        /// </summary>
        public ICollection<TypeLessons> SubCategories { get; set; }
    }
}
