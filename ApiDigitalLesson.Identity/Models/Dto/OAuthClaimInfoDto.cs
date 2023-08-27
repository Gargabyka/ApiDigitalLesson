namespace ApiDigitalLesson.Identity.Models.Dto
{
    /// <summary>
    /// Данные из claim по авторизации через внешние сервисы
    /// </summary>
    public class OAuthClaimInfoDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }
    }
}