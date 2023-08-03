namespace AspDigitalLesson.Model.Entity
{
    /// <summary>
    /// Групповой урок
    /// </summary>
    public class GroupLesson: BaseEntity
    {
        /// <summary>
        /// Наименование группы
        /// </summary>
        public string GroupName { get; set; }
        
        /// <summary>
        /// Id типа урока
        /// </summary>
        public Guid TeacherTypeLessonId { get; set; }

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

        /// <summary>
        /// Максимальное кол-во студентов группы
        /// </summary>
        public int MaxQuantityStudents { get; set; }
        
        /// <summary>
        /// Тип занятия
        /// </summary>
        public TeacherTypeLesson TeacherTypeLesson { get; set; }
    }
}
