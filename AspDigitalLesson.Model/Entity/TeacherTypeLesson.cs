using System.ComponentModel.DataAnnotations.Schema;

namespace AspDigitalLesson.Model.Entity
{
    /// <summary>
    /// Занятие преподавателей
    /// </summary>
    public class TeacherTypeLesson: BaseEntity
    {
        /// <summary>
        /// Id преподавателя
        /// </summary>
        public Guid TeacherId { get; set; }

        /// <summary>
        /// Id типа урока
        /// </summary>
        public Guid TypeLessonsId { get; set; }

        /// <summary>
        /// Признак онлайн
        /// </summary>
        public bool IsOnline { get; set; }

        /// <summary>
        /// Признак оффлайн
        /// </summary>
        public bool IsOffline { get; set; }

        /// <summary>
        /// Признак групповых занятий
        /// </summary>
        public bool IsGroup { get; set; }

        /// <summary>
        /// Признак индивидуальных занятий
        /// </summary>
        public bool IsSingle { get; set; }
        
        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Преподаватель
        /// </summary>
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }

        /// <summary>
        /// Тип урока
        /// </summary>
        [ForeignKey("TypeLessonsId")]
        public TypeLessons TypeLessons { get; set; }
    }
}
