using ApiDigitalLesson.Common.Services.Impl.SMTP;
using ApiDigitalLesson.Common.Services.Impl.Telegram;
using ApiDigitalLesson.Common.Services.Interface.SMTP;
using ApiDigitalLesson.Common.Services.Interface.Telegram;
using ApiDigitalLesson.Model.Request;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bots;

namespace ApiDigitalLesson.Common
{
    public static class Common
    {
        public static void AddCommonModules(this IServiceCollection services, IConfiguration configuration)
        {
            AddSmtp(services, configuration);
            AddTelegram(services, configuration);
        }

        private static void AddTelegram(IServiceCollection services, IConfiguration configuration)
        {
            services.AddBotClient(configuration["TelegramSettings:Token"]);
            
            services.AddTransient<ITelegramService, TelegramService>();
        }

        private static void AddSmtp(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}