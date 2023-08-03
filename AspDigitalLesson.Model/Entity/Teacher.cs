namespace AspDigitalLesson.Model.Entity
{
    /// <summary>
    /// Преподаватель
    /// </summary>
    public class Teacher: BasePerson
    {
        /// <summary>
        /// Фото
        /// </summary>
        public byte[]? Photo { get; set; }
    }
}
