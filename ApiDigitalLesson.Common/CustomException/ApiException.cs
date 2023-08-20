namespace ApiDigitalLesson.Common.CustomException
{
    /// <summary>
    /// Класс исключений для API
    /// </summary>
    public class ApiException : Exception
    {
        public ApiException() : base() { }
        public ApiException(string message) : base(message) { }

        /// <summary>
        /// Код статуса
        /// </summary>
        public int StatusCode { get; set; }
    }
}
