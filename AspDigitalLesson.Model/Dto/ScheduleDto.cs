namespace AspDigitalLesson.Model.Dto
{
    /// <summary>
    /// Модель расписания
    /// </summary>
    public class SchedulerDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Id группового занятия
        /// </summary>
        public Guid? GroupLessonId { get; set; }
        
        /// <summary>
        /// Id одиночного занятия
        /// </summary>
        public Guid? SingleLessonId { get; set; }
        
        /// <summary>
        /// Id преподавателя
        /// </summary>
        public Guid TeacherId { get; set; }
        
        /// <summary>
        /// Название урока
        /// </summary>
        public string NameLesson { get; set; }
        
        /// <summary>
        /// Название группы
        /// </summary>
        public string NameGroup { get; set; }
        
        /// <summary>
        /// Выходные
        /// </summary>
        public bool IsWeekend { get; set; }
        
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Дата начала занятия
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Дата окончания занятия
        /// </summary>
        public DateTime DateEnd { get; set; }
        
        /// <summary>
        /// Признак отмененного занятия
        /// </summary>
        public bool IsCancel { get; set; }

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
        
    }
}