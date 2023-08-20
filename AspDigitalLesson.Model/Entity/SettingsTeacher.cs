namespace AspDigitalLesson.Model.Entity
{
    public class SettingsTeacher : Settings
    {
        /// <summary>
        /// Время до которого можно отменить занятие (в часах)
        /// </summary>
        public int TimeCancelLesson { get; set; }
        
        /// <summary>
        /// Время до которого можно записаться на занятие (в часах)
        /// </summary>
        public int TimeCreateLesson { get; set; }
    }
}