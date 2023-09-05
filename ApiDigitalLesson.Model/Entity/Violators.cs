namespace ApiDigitalLesson.Model.Entity
{
    /// <summary>
    /// Сущность нарушителей
    /// </summary>
    public class Violators : BaseEntity
    {
        /// <summary>
        /// Id преподавателя
        /// </summary>
        public Guid? TeacherId { get; set; }
        
        /// <summary>
        /// Id студента
        /// </summary>
        public Guid? StudentId { get; set; }
        
        /// <summary>
        /// Время создание нарушения
        /// </summary>
        public DateTime DateCreatedViolator { get; set; }
        
        /// <summary>
        /// Жалоба
        /// </summary>
        public string Comment { get; set; }
        
        /// <summary>
        /// Пользователь отправивший жалобу
        /// </summary>
        public Guid UserId { get; set; }
        
        /// <summary>
        /// Признак бана
        /// </summary>
        public bool IsBanned { get; set; }
        
        /// <summary>
        /// Претензия отменена
        /// </summary>
        public bool IsCancel { get; set; }
        
        /// <summary>
        /// Время бана
        /// </summary>
        public DateTime? DateBan { get; set; }
        
        /// <summary>
        /// Преподаватель
        /// </summary>
        public Teacher? Teacher { get; set; }
        
        /// <summary>
        /// Студент
        /// </summary>
        public Students? Students { get; set; }
    }
}