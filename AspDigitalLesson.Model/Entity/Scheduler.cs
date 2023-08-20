namespace AspDigitalLesson.Model.Entity
{
    /// <summary>
    /// Класс расписания преподавателей
    /// </summary>
    public class Scheduler : BaseEntity
    {
        /// <summary>
        /// Id преподавателя
        /// </summary>
        public Guid TeacherId { get; set; }
        
        /// <summary>
        /// Id индивидуального занятия
        /// </summary>
        public Guid? SingleLessonId { get; set; }
        
        /// <summary>
        /// Id группового занятия
        /// </summary>
        public Guid? GroupLessonId { get; set; }
        
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
        /// Преподаватель
        /// </summary>
        public Teacher Teacher { get; set; }
        
        /// <summary>
        /// Индивидуальное занятие
        /// </summary>
        public SingleLesson SingleLesson { get; set; }
        
        /// <summary>
        /// Групповое занятия
        /// </summary>
        public GroupLesson GroupLesson { get; set; }
    }
}