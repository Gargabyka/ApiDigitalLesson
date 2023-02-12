using ApiDigitalLesson.DL.Model.Interface;

namespace ApiDigitalLesson.DL.Model.Entity
{
    /// <summary>
    /// Связь групповых занятий и студентов
    /// </summary>
    public class GroupLessonStudents: IEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id группы
        /// </summary>
        public Guid GroupId { get; set; }

        /// <summary>
        /// Id студента
        /// </summary>
        public Guid StudentsId { get; set; }

        /// <summary>
        /// Группа
        /// </summary>
        public GroupLesson Group { get; set; }

        /// <summary>
        /// Студент
        /// </summary>
        public Students Students { get; set; }
    }
}
