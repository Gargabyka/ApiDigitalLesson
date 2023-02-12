using ApiDigitalLesson.DL.Model.Interface;

namespace ApiDigitalLesson.DL.Model.Entity
{
    /// <summary>
    /// Отзывы о преподавателе
    /// </summary>
    public class AboutTeacher: IEntity
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
        /// Преподаватель
        /// </summary>
        public Teacher Teacher { get; set; }
    }
}
