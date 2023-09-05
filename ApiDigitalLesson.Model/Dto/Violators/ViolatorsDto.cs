using ApiDigitalLesson.Model.Entity;

namespace ApiDigitalLesson.Model.Dto.Violators
{
    /// <summary>
    /// Dto сущности <see cref="Violators"/>
    /// </summary>
    public class ViolatorsDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Id преподавателя
        /// </summary>
        public string? TeacherId { get; set; }
        
        /// <summary>
        /// Id студента
        /// </summary>
        public string? StudentId { get; set; }
        
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
        public string UserId { get; set; }
        
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
    }
}