namespace ApiDigitalLesson.Model.Dto.SingleLesson
{
    /// <summary>
    /// DTO сущности <see cref="SingleLesson"/>
    /// </summary>
    public class SingleLessonDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        
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
        public string CancelMessage { get; set; }

        /// <summary>
        /// Признак завершенного занятия
        /// </summary>
        public bool IsFinish { get; set; }
        
        /// <summary>
        /// Признак подтвержденного занятия преподавателем
        /// </summary>
        public bool IsConfirmedTeacher { get; set; }        
        
        /// <summary>
        /// Признак подтвержденного занятия студентом
        /// </summary>
        public bool IsConfirmedStudent { get; set; }
        
        /// <summary>
        /// Id студента
        /// </summary>
        public Guid StudentId { get; set; }
        
        /// <summary>
        /// Студент
        /// </summary>
        public StudentsDto Student { get; set; }
    }
}