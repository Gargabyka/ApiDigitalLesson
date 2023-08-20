namespace AspDigitalLesson.Model.Dto
{
    public class SettingsTeacherDto : SettingsDto
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