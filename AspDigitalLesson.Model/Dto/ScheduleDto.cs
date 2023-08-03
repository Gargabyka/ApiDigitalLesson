namespace AspDigitalLesson.Model.Dto
{
    /// <summary>
    /// Модель расписания
    /// </summary>
    public class SchedulerDto
    {
        /// <summary>
        /// Id группового занятия
        /// </summary>
        public Guid? GroupLessonId { get; set; }
        
        /// <summary>
        /// Id одиночного занятия
        /// </summary>
        public Guid? SingleLessonId { get; set; }
        
        /// <summary>
        /// Название урока
        /// </summary>
        public string NameLesson { get; set; }
        
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
        /// Признак подтвержденного занятия
        /// </summary>
        public bool IsConfirmed { get; set; }
        
    }
}