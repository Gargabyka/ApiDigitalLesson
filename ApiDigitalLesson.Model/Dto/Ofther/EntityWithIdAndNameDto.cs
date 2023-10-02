namespace ApiDigitalLesson.Model.Dto.Ofther
{
    public class EntityWithIdAndNameDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Наименование
        /// </summary>
        public string? Name { get; set; }
    }
}