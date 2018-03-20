using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.ParserCore;
using TelegramBot.ParserCore.Habra;

namespace TelegramBot
{
    class Program
    {
        static ParserWorker<string[]> parser;
        static void Main(string[] args)
        {
            Bot bot = new Bot();

            Console.WindowHeight = 10;
            Console.WindowWidth = 100;
            Console.Title = "Бот Борисыч для Telegram";
            Console.WriteLine(DateTime.Now + " Бот Борисыч запущен");

            #region For parsing           
            
            parser = new ParserWorker<string[]>(new HabraParser());
            parser.OnCompleted += ParseCommand.Parser_OnCompleted;
            parser.OnNewData += ParseCommand.Parser_OnNewData;
            parser.Settings = new HabraSettings(1, 1);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем
            TimerCallback tcb = new TimerCallback(Get2chNews);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer timer = new Timer(tcb, parser, 0, 3600000);   //будем получать новости каждый час
            #endregion

            TimerCallback tcb2 = new TimerCallback(GetLentaNews);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer timer2 = new Timer(tcb2, null, 0, 3000);   //будем отправлять сообщение в группу каждую минтуту

            bot.RunAsync().Wait();
            Console.ReadKey();
        }
        //получаем новые новости
        static void Get2chNews(object obj)
        {
            ParserWorker<string[]> parser = (ParserWorker<string[]>)obj;
            Console.WriteLine("..:: Обновление новостей ::..\n" + DateTime.Now.ToLongTimeString());
            parser.Start();
        }
        static async void GetLentaNews(object obj)
        {
            TelegramBotClient bot = new TelegramBotClient(BotSettings.Key);
            //ICommand command = new ParseCommand();
            //command.Execute(null, bot);
            Random rnd = new Random();
            int r = rnd.Next(ParseCommand.anekdots.Count);
            //await bot.SendTextMessageAsync(-156934903, ParseCommand.anekdots[r]); //Chat.ID Группы Брянск -156934903
            //await bot.SendTextMessageAsync(-156934903, "говно");
            ////Bot.ConsoleWriteLog(message);
            Console.WriteLine("Сообщение отправлено в группу");
        }
    }
}

