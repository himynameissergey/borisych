using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.ParserCore;
using TelegramBot.ParserCore.Habra;
using TelegramBot.ParserCore.Lenta;
using TelegramBot.ParserCore.Porn;

namespace TelegramBot
{
    class Program
    {
        //static ParserWorker<string[]> parser;
        static void Main(string[] args)
        {
            Bot bot = new Bot();

            Console.WindowHeight = 10;
            Console.WindowWidth = 100;
            Console.Title = "Бот Борисыч для Telegram";
            Console.WriteLine(DateTime.Now + " Бот Борисыч запущен");

            #region OkParser           
            ParserWorker<string[]>  OkParser = new ParserWorker<string[]>(new HabraParser());
            OkParser.OnCompleted += ParseCommand.Parser_OnCompleted;
            OkParser.OnNewData += ParseCommand.Parser_OnNewData;
            OkParser.Settings = new HabraSettings(1, 1);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback OkTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer OkTimer = new Timer(OkTCB, OkParser, 0, 3600000);   //будем получать новости каждый час
            #endregion

            #region LentaParser   
            ParserWorker<string[]> LentaParser = new ParserWorker<string[]>(new LentaParser());
            LentaParser.OnCompleted += LentaCommand.Parser_OnCompleted;
            LentaParser.OnNewData += LentaCommand.Parser_OnNewData;
            LentaParser.Settings = new LentaSettings(1, 1);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback LentaTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer LentaTimer = new Timer(LentaTCB, LentaParser, 0, 3600000);   //будем получать новости каждый час
            #endregion

            #region PornParser   
            ParserWorker<string[]> PornParser = new ParserWorker<string[]>(new PornParser());
            PornParser.OnCompleted += PornCommand.Parser_OnCompleted;
            PornParser.OnNewData += PornCommand.Parser_OnNewData;
            PornParser.Settings = new PornSettings(1, 1);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback PornTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer PornTimer = new Timer(PornTCB, PornParser, 0, 3600000);   //будем получать новости каждый час
            #endregion

            //TimerCallback tcb2 = new TimerCallback(GetLentaNews);	// устанавливаем метод обратного вызова
            //// создаем таймер
            //Timer timer2 = new Timer(tcb2, null, 0, 3000);   //будем отправлять сообщение в группу каждую минтуту

            bot.RunAsync().Wait();
            Console.ReadKey();
            
        }
        //получаем новые новости
        static void GetNewsUpdate(object obj)
        {
            ParserWorker<string[]> parser = (ParserWorker<string[]>)obj;
            Console.WriteLine("..:: Обновление контента ::..\n" + DateTime.Now.ToLongTimeString());
            parser.Start();
        }
        //static async void GetLentaNews(object obj)
        //{
        //    TelegramBotClient bot = new TelegramBotClient(BotSettings.Key);
        //    //ICommand command = new ParseCommand();
        //    //command.Execute(null, bot);
        //    Random rnd = new Random();
        //    int r = rnd.Next(ParseCommand.anekdots.Count);
        //    await bot.SendTextMessageAsync(-156934903, ParseCommand.anekdots[r]); //Chat.ID Группы Брянск -156934903
        //    //await bot.SendTextMessageAsync(-156934903, "говно");
        //    ////Bot.ConsoleWriteLog(message);
        //    Console.WriteLine("Сообщение отправлено в группу");
        //}
    }
}

