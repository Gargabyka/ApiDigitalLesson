namespace ApiDigitalLesson.Identity.Exception
{
    /// <summary>
    /// Класс исключений для API
    /// </summary>
    public class ApiException : System.Exception
    {
        public ApiException() : base() { }
        public ApiException(string message) : base(message) { }

        /// <summary>
        /// Код статуса
        /// </summary>
        public int StatusCode { get; set; }
    }
}
