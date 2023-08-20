namespace AspDigitalLesson.Model.Dto
{
    /// <summary>
    /// DTO создания индивидуального урока
    /// </summary>
    public class CreateSingleLessonDto
    {
        /// <summary>
        /// Id преподавателя
        /// </summary>
        public string TeacherTypeLessonId { get; set; }
        
        /// <summary>
        /// Id студента
        /// </summary>
        public string StudentId { get; set; }
        
        /// <summary>
        /// Описание занятия
        /// </summary>
        public string Description { get; set; }
        
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