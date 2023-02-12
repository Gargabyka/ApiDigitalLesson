using ApiDigitalLesson.DL.Model.Interface;

namespace ApiDigitalLesson.DL.Model.Entity
{
    /// <summary>
    /// Тип занятия
    /// </summary>
    public class TypeLessons: IEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название занятия
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание занятие
        /// </summary>
        public string Discription { get; set; }
    }
}
