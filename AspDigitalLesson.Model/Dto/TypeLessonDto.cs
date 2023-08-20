using AspDigitalLesson.Model.Enums;

namespace AspDigitalLesson.Model.Dto
{
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
        /// Категория
        /// </summary>
        public int? Category { get; set; }

        /// <summary>
        /// Родитель
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}