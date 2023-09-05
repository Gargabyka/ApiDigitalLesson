using ApiDigitalLesson.Model.Request;

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
