namespace ApiDigitalLesson.Identity.Models.Request
{
    /// <summary>
    /// Запрос обновления токена
    /// </summary>
    public class RefreshTokenRequest
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Токен
        /// </summary>
        public string Token { get; set; }
    }
}
