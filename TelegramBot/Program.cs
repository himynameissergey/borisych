using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.ParserCore;
using TelegramBot.ParserCore.Habra;
using TelegramBot.ParserCore.Anek;
using TelegramBot.ParserCore.Lenta;
using TelegramBot.ParserCore.Pikabu;
using TelegramBot.ParserCore._2chn;
using TelegramBot.ParserCore._2chb;
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

            #region AnekParser           
            ParserWorker<string[]> AnekParser = new ParserWorker<string[]>(new AnekParser());
            AnekParser.OnCompleted += AnekCommand.Parser_OnCompleted;
            AnekParser.OnNewData += AnekCommand.Parser_OnNewData;
            AnekParser.Settings = new AnekSettings(1, 3);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback AnekTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer AnekTimer = new Timer(AnekTCB, AnekParser, 0, 3600000);   //будем получать новости каждый час
            #endregion

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

            #region PikabuParser   
            ParserWorker<string[]> PikabuParser = new ParserWorker<string[]>(new PikabuParser());
            PikabuParser.OnCompleted += PikabuCommand.Parser_OnCompleted;
            PikabuParser.OnNewData += PikabuCommand.Parser_OnNewData;
            PikabuParser.Settings = new PikabuSettings(1, 1);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback PikabuTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer PikabuTimer = new Timer(PikabuTCB, PikabuParser, 0, 3600000);   //будем получать новости каждый час
            #endregion

            #region _2chbParser   
            ParserWorker<string[]> _2chbParser = new ParserWorker<string[]>(new _2chbParser());
            _2chbParser.OnCompleted += _2chbCommand.Parser_OnCompleted;
            _2chbParser.OnNewData += _2chbCommand.Parser_OnNewData;
            _2chbParser.Settings = new _2chbSettings(1, 1);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback _2chbTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer _2chbTimer = new Timer(_2chbTCB, _2chbParser, 0, 3600000);   //будем получать новости каждый час
            #endregion

            #region _2chnParser   
            ParserWorker<string[]> _2chnParser = new ParserWorker<string[]>(new _2chnParser());
            _2chnParser.OnCompleted += _2chnCommand.Parser_OnCompleted;
            _2chnParser.OnNewData += _2chnCommand.Parser_OnNewData;
            _2chnParser.Settings = new _2chnSettings(1, 1);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback _2chnTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer _2chnTimer = new Timer(_2chnTCB, _2chnParser, 0, 3600000);   //будем получать новости каждый час
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

