namespace AspDigitalLesson.Model.Entity
{
    /// <summary>
    /// Базовый класс урок
    /// </summary>
    public abstract class Lesson : BaseEntity
    {
        /// <summary>
        /// Id типа занятия
        /// </summary>
        public Guid TeacherTypeLessonId { get; set; }

        /// <summary>
        /// Признак отмененного занятия
        /// </summary>
        public bool IsCancel { get; set; }
        
        /// <summary>
        /// Обоснование отмененного урока
        /// </summary>
        public string? CancelMessage { get; set; }

        /// <summary>
        /// Признак завершенного занятия
        /// </summary>
        public bool IsFinish { get; set; }
        
        /// <summary>
        /// Признак подтвержденного занятия преподавателем
        /// </summary>
        public bool IsConfirmedForTeacher { get; set; }
        
        /// <summary>
        /// Признак подтвержденного занятия студентом
        /// </summary>
        public bool IsConfirmedForStudent { get; set; }
        
        /// <summary>
        /// Тип занятия
        /// </summary>
        public TeacherTypeLesson TeacherTypeLesson { get; set; }
    }
}