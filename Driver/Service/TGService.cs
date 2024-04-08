using System;
using Driver.Models;
using Newtonsoft.Json;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Driver.Service;
using Telegram.Bot;

public interface TGMessage
{
    String subject { get; }
    String senderInfoBody { get; }
}
public class TGService
{
    private TelegramBotClient client => GetBotClient();
    private TelegramBotClient _client;
    
    private TelegramAccount _tgAccount = JsonConvert.DeserializeObject<TelegramAccount>(
        System.IO.File.ReadAllText("SecretInfo/tgInfo.json")
        );

    public async void SendMessageAsync(TGMessage tgMessage)
    {
        Message message = await client.SendTextMessageAsync(
            chatId: _tgAccount.chatId,
            text: $"""
                  *{tgMessage.subject}*
                  
                  {tgMessage.senderInfoBody}
                  """,
            parseMode: ParseMode.MarkdownV2,
            disableNotification: true
        );
    }

    private TelegramBotClient GetBotClient()
    {
        if (_client != null)
        {
            return _client;
        }

        TelegramBotClient newClient = new TelegramBotClient(_tgAccount.token);
        _client = newClient;
        return newClient;
    }
}