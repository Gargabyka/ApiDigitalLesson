namespace ApiDigitalLesson.DL.Model.Entity
{
    /// <summary>
    /// Тип занятия
    /// </summary>
    public class TypeLessons: BaseEntity
    {
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
