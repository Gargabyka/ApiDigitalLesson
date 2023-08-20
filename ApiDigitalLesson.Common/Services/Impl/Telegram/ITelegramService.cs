using Telegram.Bots.Types;

namespace ApiDigitalLesson.Common.Services.Impl.Telegram
{
    public interface ITelegramService
    {
        Task<Response<TextMessage>> SendMessageAsync(long chatId, string text);
    }
}