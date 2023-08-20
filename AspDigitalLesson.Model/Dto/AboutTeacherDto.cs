using AspDigitalLesson.Model.Entity;

namespace AspDigitalLesson.Model.Dto
{
    /// <summary>
    /// DTO сущности <see cref="AboutTeacher"/>
    /// </summary>
    public class AboutTeacherDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id преподавателя
        /// </summary>
        public Guid TeacherId { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }
        
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }
        
        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// Рейтинг
        /// </summary>
        public int Rating { get; set; }


    }
}
