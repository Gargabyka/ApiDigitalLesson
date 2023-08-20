namespace AspDigitalLesson.Model.Entity
{
    /// <summary>
    /// Базовая сущность настроек
    /// </summary>
    public abstract class Settings : BaseEntity
    {
        /// <summary>
        /// Разрешить создавать занятия в своем календаре
        /// </summary>
        public bool IsAllowCreateLesson { get; set; }
        
        /// <summary>
        /// Разрешить отправку уведомлений в телеграмм
        /// </summary>
        public bool IsNotificationTelegram { get; set; }
        
        /// <summary>
        /// Уведомление о заявке на занятие в телеграмм
        /// </summary>
        public bool IsRequestForLessonTelegram { get; set; }
        
        /// <summary>
        /// Уведомление о принятии занятия в телеграмм
        /// </summary>
        public bool IsAcceptForLessonTelegram { get; set; }
        
        /// <summary>
        /// Уведомлять об отмененном занятии в телеграм
        /// </summary>
        public bool IsCancelLessonTelegram { get; set; }
        
        /// <summary>
        /// Уведомлять о скором занятии в телеграмм
        /// </summary>
        public bool IsLessonComingSoonTelegram { get; set; }
        
        /// <summary>
        /// Время уведомления до занятия (в часах)
        /// </summary>
        public int TimeBeforeLesson { get; set; }
        
        /// <summary>
        /// Разрешить отправку уведомлений на email
        /// </summary>
        public bool IsNotificationEmail { get; set; }
        
        /// <summary>
        /// Уведомление о заявке на занятие на email
        /// </summary>
        public bool IsRequestForLessonEmail { get; set; }
        
        /// <summary>
        /// Уведомление о принятии занятия на email
        /// </summary>
        public bool IsAcceptForLessonEmail { get; set; }
        
        /// <summary>
        /// Уведомлять о скором занятии на email
        /// </summary>
        public bool IsCancelLessonEmail { get; set; }
        
        /// <summary>
        /// Уведомлять о скором занятии на email
        /// </summary>
        public bool IsLessonComingSoonEmail { get; set; }
    }
}