using ApiDigitalLesson.DL.Model.Interface;

namespace ApiDigitalLesson.DL.Model.Entity
{
    /// <summary>
    /// Одиночный урок
    /// </summary>
    public class SingleLesson : IEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id студента
        /// </summary>
        public Guid StudentsId { get; set; }

        /// <summary>
        /// Id типа занятия
        /// </summary>
        public Guid TypeLessonId { get; set; }

        /// <summary>
        /// Дата начала занятия
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Дата окончания занятия
        /// </summary>
        public DateTime DateEnd { get; set; }

        /// <summary>
        /// Признак отмененного занятия
        /// </summary>
        public bool IsCancel { get; set; }

        /// <summary>
        /// Признак завершенного занятия
        /// </summary>
        public bool IsFinish { get; set; }

        /// <summary>
        /// Студент
        /// </summary>
        public Students Students { get; set; }

        /// <summary>
        /// Тип занятия
        /// </summary>
        public TeacherTypeLesson TypeLesson { get; set; }
    }
}
