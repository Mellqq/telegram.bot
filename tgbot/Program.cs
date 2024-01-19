using Telegram.Bot;
using Telegram.Bot.Types;

namespace tgbot
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TelegramBotClient("6917749309:AAG88AbaNNxvM_sY41CK_B69RdBhn0QGJ3A");
            client.StartReceiving(Update, Error);
            Console.ReadLine();
        }

         async private static Task Update(ITelegramBotClient botclient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (message.Text != null) 
            {
               Console.WriteLine($"{message.Chat.FirstName}    |    {message.Text}");
                if (message.Text.ToLower().Contains("здарова"))
                {
                    await botclient.SendTextMessageAsync(message.Chat.Id,"Привет");
                    return;
                }
            }
            if(message.Photo != null)
            {
                await botclient.SendTextMessageAsync(message.Chat.Id, "классное фото,но отправь его файлом и я его отредактирую");
                return;
            }
            if (message.Photo != null)
            {
                if (message.Document != null)
                {
                    await botclient.SendTextMessageAsync(message.Chat.Id, "не отредактирую, мне впадлу скачивать фотошоп, а без него никак");
                    return;
                }
            }
        }

        private static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
