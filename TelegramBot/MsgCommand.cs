using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot
{
    class MsgCommand : ICommand
    {
        static List<string> lines = ReadingTextFile.GetLinesOfTextFile();

        public string Name { get; set; } = "/msg";
        public async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = -1001315811997; //-1001315811997 - ChatId супергруппы Брянск    //message.Chat.Id; 
            //var messageId = message.MessageId;
            //DateTime now = DateTime.Now;
            string say = message.Text.Substring(5); //обрезаем первые 5 символов (/msg )
            await client.SendTextMessageAsync(chatId, say);//, replyToMessageId: messageId);
            Bot.ConsoleWriteLog(message);
        }
     }

}
