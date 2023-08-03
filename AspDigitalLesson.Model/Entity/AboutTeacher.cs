namespace AspDigitalLesson.Model.Entity
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
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Преподаватель
        /// </summary>
        public Teacher Teacher { get; set; }
    }
}
