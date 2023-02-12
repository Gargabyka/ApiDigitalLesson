using ApiDigitalLesson.Identity.Models.Request;

namespace ApiDigitalLesson.Identity.Services.Interface
{
    /// <summary>
    /// Интерфейс отправки сообщения на email
    /// </summary>
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
