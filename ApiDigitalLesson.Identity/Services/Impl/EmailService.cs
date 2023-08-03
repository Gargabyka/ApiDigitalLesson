using ApiDigitalLesson.Identity.Exception;
using ApiDigitalLesson.Identity.Models.Request;
using ApiDigitalLesson.Identity.Services.Interface;
using Microsoft.Extensions.Options;
using MimeKit;

namespace ApiDigitalLesson.Identity.Services.Impl
{
    /// <summary>
    /// Сервис для отправки email сообщений
    /// </summary>
    public class EmailService: IEmailService
    {
        private readonly MailSettings _mailSettings;

        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendAsync(EmailRequest request)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_mailSettings.EmailFrom));
                email.Sender = MailboxAddress.Parse(_mailSettings.EmailFrom);
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;

                var builder = new BodyBuilder();
                builder.HtmlBody = request.Body;
                email.Body = builder.ToMessageBody();

                using var client = new MailKit.Net.Smtp.SmtpClient();
                await client.ConnectAsync(_mailSettings.SmtpHost, _mailSettings.SmtpPort, true);
                await client.AuthenticateAsync(_mailSettings.SmtpUser, _mailSettings.SmtpPass);

                await client.SendAsync(email);

                await client.DisconnectAsync(true);
            }
            catch (System.Exception e)
            {
                throw new ApiException($"{e.InnerException}");
            }
        }
    }
}
