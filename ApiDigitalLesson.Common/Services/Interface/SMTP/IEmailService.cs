using ApiDigitalLesson.Identity.Models.Request;

namespace ApiDigitalLesson.Common.Services.Interface.SMTP
{
    /// <summary>
    /// Интерфейс отправки сообщения на email
    /// </summary>
    public interface IEmailService
    {
        Task PostAsync(EmailRequest request);
    }
}
