namespace ApiDigitalLesson.DL.Model.Entity
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
        /// Признак оффлайн
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
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Преподаватель
        /// </summary>
        public Teacher Teacher { get; set; }

        /// <summary>
        /// Тип урока
        /// </summary>
        public TypeLessons TypeLessons { get; set; }
    }
}
