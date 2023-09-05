namespace ApiDigitalLesson.Model.Entity
{
    /// <summary>
    /// Одиночный урок
    /// </summary>
    public class SingleLesson : Lesson
    {
        /// <summary>
        /// Id студента
        /// </summary>
        public Guid StudentsId { get; set; }

        /// <summary>
        /// Студент
        /// </summary>
        public Students Students { get; set; }
    }
}
