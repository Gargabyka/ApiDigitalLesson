namespace ApiDigitalLesson.Model.Entity
{
    /// <summary>
    /// Отзывы о преподавателе
    /// </summary>
    public class AboutTeacher: BaseEntity
    {
        /// <summary>
        /// Id преподавателя
        /// </summary>
        public Guid TeacherId { get; set; }
        
        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// Рейтинг
        /// </summary>
        public int Rating { get; set; }
        
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Преподаватель
        /// </summary>
        public Teacher Teacher { get; set; }
    }
}
