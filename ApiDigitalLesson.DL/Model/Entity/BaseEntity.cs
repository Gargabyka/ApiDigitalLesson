using ApiDigitalLesson.DL.Model.Interface;

namespace ApiDigitalLesson.DL.Model.Entity
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public class BaseEntity : IEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
    }
}
