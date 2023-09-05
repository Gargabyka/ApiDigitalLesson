namespace ApiDigitalLesson.Model.Dto.Notification
{
    /// <summary>
    /// DTO информации о уроке для отправки уведомления
    /// </summary>
    public class NotificationLessonInformationDto
    {
        /// <summary>
        /// Имя преподавателя
        /// </summary>
        public string TeacherName { get; set; }
        
        /// <summary>
        /// Название группы
        /// </summary>
        public string GroupName { get; set; }
        
        /// <summary>
        /// Имя студента
        /// </summary>
        public string StudentName { get; set; }
        
        /// <summary>
        /// Причина отмены занятия
        /// </summary>
        public string? CancelMessage { get; set; }
        
        /// <summary>
        /// Название урока
        /// </summary>
        public string NameLesson { get; set; }
        
        /// <summary>
        /// Дата начала занятия
        /// </summary>
        public DateTime StartDate { get; set; }
    }
}