using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Common.Services.Interface.SMTP;
using ApiDigitalLesson.Identity.Models.Request;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace ApiDigitalLesson.Common.Services.Impl.SMTP
{
    /// <summary>
    /// Сервис для отправки email сообщений
    /// </summary>
    public class EmailService: IEmailService
    {
        private readonly MailSettings _mailSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<MailSettings> mailSettings, ILogger<EmailService> logger)
        {
            _logger = logger;
            _mailSettings = mailSettings.Value;
        }

        public async Task PostAsync(EmailRequest request)
        {
            FillAdditionalParams(request);

            await SendAsync(request);
        }

        private async Task SendAsync(EmailRequest request)
        {
            try
            {
                var emailMessage = GetEmailMessage(request);

                using var client = new SmtpClient();
                await client.ConnectAsync(_mailSettings.SmtpHost, _mailSettings.SmtpPort, true);
                await client.AuthenticateAsync(_mailSettings.SmtpUser, _mailSettings.SmtpPass);

                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
            catch (Exception e)
            {
                var message = $"Произошла ошибка при отправки сообщения по SMTP, {e.InnerException}";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }

        private void FillAdditionalParams(EmailRequest request)
        {
            request.From = _mailSettings.EmailFrom;
            request.Sender = _mailSettings.Sender;
        }

        private MimeMessage GetEmailMessage(EmailRequest request)
        {
            var email = new MimeMessage();
            
            email.From.Add(new MailboxAddress(request.Sender, request.From));
            email.To.Add(new MailboxAddress(request.ToName, request.ToAddress));
            
            email.Subject = request.Subject;

            email.Body = BuildBody(request);

            return email;
        }

        private MimeEntity BuildBody(EmailRequest request)
        {
            return new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = GenerateHtml(request)
            };
        }

        private string GenerateHtml(EmailRequest request)
        {
            var link = !request.Link.IsNull()
                ? $@"<a class=""button"" href=""{request.Link}"">Перейти на сайт</a>"
                : string.Empty;

            if (request.Body.Contains("\n"))
            {
                request.Body = request.Body.Replace("\n", "<br>");
            }
            
            var result = $@"
            <!DOCTYPE html>
                <html>
                <head>
                <style>
                    body{{
                        font-family: Arial, sans-serif;
                        background-color: #f0f0f0;
                    }}
                    .container{{
                        max-width: 500px;
                        margin: 0 auto;
                        padding: 20px;
                        background-color: #fff;
                        border-radius: 5px;
                        box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
                    }}
                    .title{{
                        font-size: 24px;
                        color: #666;
                        line-height: 1.5;
                        margin-bottom: 20px;
                    }}
                    .text{{
                        font-size: 16px;
                        color: #666;
                        line-height: 1.5;
                        margin-bottom: 20px;
                    }}
                    .button{{
                        display: inline-block;
                        background-color: #007bff;
                        color: #fff;
                        font-size: 16px;
                        font-weight: bold;
                        text-decoration: none;
                        padding: 10px 20px;
                        border-radius: 5px;
                    }}
                .button:hover{{
                    background-color: #0056b3;
                }}
            </style>
            </head>
            <body>
                <div class=""container"">
                <h1 class=""title"">Добро пожаловать на сайт ApiDigitalLesson</h1>
                <p class=""text"">{request.Body}</p>
                {link}
                </div>
            </body>
            </html>";

            return result;
        }
    }
}
