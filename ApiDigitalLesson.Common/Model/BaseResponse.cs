namespace ApiDigitalLesson.Common.Model
{
    /// <summary>
    /// Базовый класс результата запроса
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponse<T>
    {
        public BaseResponse()
        {

        }
        public BaseResponse(string? message)
        {
            Message = message;
        }
        public BaseResponse(string? message, bool succeeded)
        {
            Message = message;
            Succeeded = succeeded;
        }
        public BaseResponse(T data, string? message = null)
        {
            Message = message;
            Data = data;
        }
        public BaseResponse(T data, bool succeeded, string? message = null)
        {
            Message = message;
            Data = data;
            Succeeded = succeeded;
        }
        
        public bool Succeeded;
        public string? Message { get; set; }
        public List<string> Errors = null!;
        public T Data { get; set; } = default!;
    }
}
