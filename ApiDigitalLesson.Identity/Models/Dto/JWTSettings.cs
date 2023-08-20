namespace ApiDigitalLesson.Identity.Models.Dto
{
    /// <summary>
    /// Настройки JWT токена
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Ключ
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Издатель
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Продолжительность сессии
        /// </summary>
        public double DurationInMinutes { get; set; }
    }
}
