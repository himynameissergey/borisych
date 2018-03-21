using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.ParserCore;
using TelegramBot.ParserCore.Habra;

namespace TelegramBot
{
    class LentaCommand : ICommand
    {
        /// <summary>
        /// Имя команды
        /// </summary>
        public string Name { get; set; } = "/lenta";
        public int CountArgs { get; set; } = 0;

        //ParserWorker<string[]> parser;
        public static List<string> anekdots = new List<string>();
        /// <summary>
        /// Вызывает команду
        /// </summary>
        /// <param name="message">принимает сообщение</param>
        /// <param name="client">Ссылка на экземпляр бота</param>
        public async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            //parser = new ParserWorker<string[]>(new HabraParser());
            //parser.OnCompleted += Parser_OnCompleted;
            //parser.OnNewData += Parser_OnNewData;
            //parser.Settings = new HabraSettings(1, 1);  // первая страница сайта
            //parser.Start();

            Random rnd = new Random();
            int r = rnd.Next(anekdots.Count);
            await client.SendTextMessageAsync(chatId, anekdots[r]); //Chat.ID Группы Брянск -156934903
            Bot.ConsoleWriteLog(message);
        }
        public async void OnError(Message message, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(message.Chat.Id, @"Введите ""/lenta"" ");
            Bot.ConsoleWriteLog(message);
        }
        public static void Parser_OnCompleted(object obj)
        {
            Console.WriteLine("\nПарсер lenta.ru отработал!\n");
        }
        public static void Parser_OnNewData(object arg1, string[] arg2)
        {
            for (int i = 0; i < arg2.Length; i++)
            {
                arg2[i] = arg2[i].Replace("\n", "");
                Console.WriteLine(arg2[i]);
            }
            anekdots.AddRange(arg2);
        }
    }
}
