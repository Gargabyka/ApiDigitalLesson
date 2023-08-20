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
        
        /// <summary>
        /// Id настроек преподавателя
        /// </summary>
        public Guid SettingsTeacherId { get; set; }
        
        /// <summary>
        /// Настройки преподавателя
        /// </summary>
        public SettingsTeacher SettingsTeacher { get; set; }
    }
}
