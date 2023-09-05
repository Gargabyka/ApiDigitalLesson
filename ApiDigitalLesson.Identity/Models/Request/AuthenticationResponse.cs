namespace ApiDigitalLesson.Identity.Models.Request
{
    /// <summary>
    /// Запрос аутентификации
    /// </summary>
    public class AuthenticationResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        public string Roles { get; set; }

        /// <summary>
        /// Признак подтвержденного аккаунта
        /// </summary>
        public bool IsVerified { get; set; }

        /// <summary>
        /// JWT токен 
        /// </summary>
        public string JwToken { get; set; }

        /// <summary>
        /// Обновленный токен
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
