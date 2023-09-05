using ApiDigitalLesson.Common.Extension;
using ApiDigitalLesson.Common.Services.Interface.Telegram;
using Microsoft.Extensions.Logging;
using Telegram.Bots;
using Telegram.Bots.Requests;
using Telegram.Bots.Types;

namespace ApiDigitalLesson.Common.Services.Impl.Telegram
{
    /// <summary>
    /// Сервис работы с Telegram
    /// </summary>
    public class TelegramService : ITelegramService
    {
        private readonly IBotClient _bot;
        private readonly ILogger<TelegramService> _logger;

        public TelegramService(IBotClient bot, ILogger<TelegramService> logger)
        {
            _bot = bot;
            _logger = logger;
        }

        //TODO:Переделать на WebHook для получения Telegram Id
        /// <summary>
        /// Отправить сообщение через телеграмм
        /// </summary>
        public async Task<Response<TextMessage>> SendMessageAsync(long chatId, string text)
        {
            try
            {
                if (chatId == 0)
                {
                    throw new Exception("Передан пустой chatId.");
                }

                if (text.IsNull())
                {
                    throw new Exception("Текст сообщения не может быть пустым.");
                }

                var request = new SendText(chatId,text);

                var response = await _bot.HandleAsync(request);

                if (response.Ok)
                {
                    return response;
                }
                
                var message =
                    $"Произошла ошибка при попытки отправить сообщение через телеграмм: {response.Result}.";
                _logger.LogError(message);

                return response;
            }
            catch (Exception e)
            {
                var message = $"Произошла ошибка при попытке отправить сообщение через телеграмм: {e.Message}.";
                _logger.LogError(message);
                throw new Exception(message);
            }
        }
    }
}