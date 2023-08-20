using AspDigitalLesson.Model.Entity;

namespace AspDigitalLesson.Model.Dto
{
    /// <summary>
    /// DTO сущности <see cref="TeacherTypeLesson"/>
    /// </summary>
    public class TeacherTypeLessonDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Id преподавателя
        /// </summary>
        public string TeacherId { get; set; }
        
        /// <summary>
        /// Id типа урока преподавателя
        /// </summary>
        public string TypeLessonId { get; set; }

        /// <summary>
        /// Типа урока
        /// </summary>
        public TypeLessonDto? TypeLessons { get; set; }

        /// <summary>
        /// Признак онлайн
        /// </summary>
        public bool? IsOnline { get; set; }

        /// <summary>
        /// Признак оффлайн
        /// </summary>
        public bool? IsOffline { get; set; }

        /// <summary>
        /// Признак групповых занятий
        /// </summary>
        public bool? IsGroup { get; set; }

        /// <summary>
        /// Признак индивидуальных занятий
        /// </summary>
        public bool? IsSingle { get; set; }
        
        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal? Price { get; set; }
    }
}