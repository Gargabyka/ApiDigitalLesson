namespace ApiDigitalLesson.Model.Entity
{
    /// <summary>
    /// Групповой урок
    /// </summary>
    public class GroupLesson: Lesson
    {
        /// <summary>
        /// Наименование группы
        /// </summary>
        public string GroupName { get; set; }
        
        /// <summary>
        /// Максимальное кол-во студентов группы
        /// </summary>
        public int MaxQuantityStudents { get; set; }
    }
}
