namespace ApiDigitalLesson.Common.CustomException
{
    /// <summary>
    /// Исключение при добавлении данных
    /// </summary>
    public class AddException : Exception
    {
        public AddException() : base() { }
        public AddException(string message) : base(message) { }
    }
}