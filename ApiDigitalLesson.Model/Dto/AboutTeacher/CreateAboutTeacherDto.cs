using System.ComponentModel.DataAnnotations;

namespace ApiDigitalLesson.Model.Dto.AboutTeacher
{
    /// <summary>
    /// Dto создание отзыва о преподавателе
    /// </summary>
    public class CreateAboutTeacherDto
    {
        /// <summary>
        /// Id преподавателя
        /// </summary>
        [Required]
        public Guid TeacherId { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        [Required]
        public string Comment { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// Рейтинг
        /// </summary>
        [Range(1, 5)]
        public int Rating { get; set; }
    }
}