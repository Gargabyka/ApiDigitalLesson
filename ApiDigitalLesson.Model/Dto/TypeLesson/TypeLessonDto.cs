using ApiDigitalLesson.Model.Entity;

namespace ApiDigitalLesson.Model.Dto.TypeLesson
{
    /// <summary>
    /// DTO сущности <see cref="TypeLessons"/>
    /// </summary>
    public class TypeLessonDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Наименование занятия
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Описание занятия
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Родитель
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}