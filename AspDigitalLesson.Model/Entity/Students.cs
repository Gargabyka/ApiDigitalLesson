#nullable enable
namespace AspDigitalLesson.Model.Entity
{
    /// <summary>
    /// Студент
    /// </summary>
    public class Students: BasePerson
    {
        /// <summary>
        /// Id настроек студента
        /// </summary>
        public Guid SettingsStudentId { get; set; }
        
        /// <summary>
        /// Настройки студента
        /// </summary>
        public SettingsStudent SettingsStudent { get; set; }
    }
}
