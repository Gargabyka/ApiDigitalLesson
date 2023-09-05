namespace ApiDigitalLesson.Model.Dto.Scheduler
{
    /// <summary>
    /// DTO проверки пересечения дат
    /// </summary>
    public class IntersectionDatesDto
    {
        /// <summary>
        /// Id преподавателя
        /// </summary>
        public string TeacherId { get; set; }
        
        /// <summary>
        /// Id студента
        /// </summary>
        public string StudentId { get; set; }
        
        /// <summary>
        /// Дата начала
        /// </summary>
        public DateTime DateStart { get; set; }
        
        /// <summary>
        /// Дата окончания
        /// </summary>
        public DateTime DateEnd { get; set; }
    }
}