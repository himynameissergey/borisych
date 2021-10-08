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
using TelegramBot.ParserCore.Reddit;
using TelegramBot.ParserCore.KMP;
using TelegramBot.ParserCore.Arhivach;
using TelegramBot.ParserCore.vk;
using TelegramBot.ParserCore.Pen;
using TelegramBot.ParserCore._9gag;
using TelegramBot.ParserCore.Bash;
using TelegramBot.ParserCore.Photo;
using TelegramBot.ParserCore.BryanskToday;
using TelegramBot.ParserCore.GorodTV;

namespace TelegramBot
{
    class Program
    {
        //static ParserWorker<string[]> parser;
        static void Main(string[] args)
        {
            Bot bot = new Bot();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WindowHeight = 20;
            Console.WindowWidth = 100;
            Console.Title = "Бот Борисыч для Telegram";
            Console.WriteLine(DateTime.Now + " Бот Борисыч запущен");

            #region AnekParser           
            ParserWorker<string[]> AnekParser = new ParserWorker<string[]>(new AnekParser());
            AnekParser.OnCompleted += AnekCommand.Parser_OnCompleted;
            AnekParser.OnNewData += AnekCommand.Parser_OnNewData;
            AnekParser.Settings = new AnekSettings(1, 1);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback AnekTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer AnekTimer = new Timer(AnekTCB, AnekParser, 0, 3600000);   //будем получать новости каждый час
            #endregion

            #region OkParser           
            //ParserWorker<string[]> OkParser = new ParserWorker<string[]>(new HabraParser());
            //OkParser.OnCompleted += ParseCommand.Parser_OnCompleted;
            //OkParser.OnNewData += ParseCommand.Parser_OnNewData;
            //OkParser.Settings = new HabraSettings(1, 1);  // первая страница сайта
            ////parser.Start();   //при работе с таймером эту строчку закомментируем

            //TimerCallback OkTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            //// создаем таймер
            //Timer OkTimer = new Timer(OkTCB, OkParser, 0, 3600000);   //будем получать новости каждый час
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

            #region RedditParser           
            ParserWorker<string[]> RedditParser = new ParserWorker<string[]>(new RedditParser());
            RedditParser.OnCompleted += RedditCommand.Parser_OnCompleted;
            RedditParser.OnNewData += RedditCommand.Parser_OnNewData;
            RedditParser.Settings = new RedditSettings(1, 1);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback RedditTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer RedditTimer = new Timer(RedditTCB, RedditParser, 0, 3600000);   //будем получать новости каждый час
            #endregion

            #region KMPParser           
            ParserWorker<string[]> KMPParser = new ParserWorker<string[]>(new KMPParser());
            KMPParser.OnCompleted += KMPCommand.Parser_OnCompleted;
            KMPParser.OnNewData += KMPCommand.Parser_OnNewData;
            KMPParser.Settings = new KMPSettings(1, 1);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback KMPTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer KMPTimer = new Timer(KMPTCB, KMPParser, 0, 3600000);   //будем получать новости каждый час
            #endregion

            #region ArhivachParser           
            ParserWorker<string[]> ArhivachParser = new ParserWorker<string[]>(new ArhivachParser());
            ArhivachParser.OnCompleted += ArhivachCommand.Parser_OnCompleted;
            ArhivachParser.OnNewData += ArhivachCommand.Parser_OnNewData;
            ArhivachParser.Settings = new ArhivachSettings(1, 1);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback ArhivachTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer ArhivachTimer = new Timer(ArhivachTCB, ArhivachParser, 0, 3600000);   //будем получать новости каждый час
            #endregion  

            #region vkParser           
            ParserWorker<string[]> vkParser = new ParserWorker<string[]>(new vkParser());
            vkParser.OnCompleted += vkCommand.Parser_OnCompleted;
            vkParser.OnNewData += vkCommand.Parser_OnNewData;
            vkParser.Settings = new vkSettings(1, 1);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback vkTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer vkTimer = new Timer(vkTCB, vkParser, 0, 3600000);   //будем получать новости каждый час
            #endregion

            #region PenParser           
            ParserWorker<string[]> PenParser = new ParserWorker<string[]>(new PenParser());
            PenParser.OnCompleted += PenCommand.Parser_OnCompleted;
            PenParser.OnNewData += PenCommand.Parser_OnNewData;
            PenParser.Settings = new PenSettings(1, 5);  // 5 страниц сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback PenTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer PenTimer = new Timer(PenTCB, PenParser, 0, 3600000);   //будем получать новости каждый час
            #endregion

            #region _9gagParser           
            ParserWorker<string[]> _9gagParser = new ParserWorker<string[]>(new _9gagParser());
            _9gagParser.OnCompleted += _9gagCommand.Parser_OnCompleted;
            _9gagParser.OnNewData += _9gagCommand.Parser_OnNewData;
            _9gagParser.Settings = new _9gagSettings(1, 1);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback _9gagTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer _9gagTimer = new Timer(_9gagTCB, _9gagParser, 0, 3600000);   //будем получать новости каждый час
            #endregion

            #region BashParser           
            ParserWorker<string[]> BashParser = new ParserWorker<string[]>(new BashParser());
            BashParser.OnCompleted += BashCommand.Parser_OnCompleted;
            BashParser.OnNewData += BashCommand.Parser_OnNewData;
            BashParser.Settings = new BashSettings(1, 1);  // 1 страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback BashTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer BashTimer = new Timer(BashTCB, BashParser, 0, 3600000);   //будем получать новости каждый час
            #endregion

            #region PhotoParser   
            ParserWorker<string[]> PhotoParser = new ParserWorker<string[]>(new PhotoParser());
            PhotoParser.OnCompleted += PhotoCommand.Parser_OnCompleted;
            PhotoParser.OnNewData += PhotoCommand.Parser_OnNewData;
            PhotoParser.Settings = new PhotoSettings(1, 1);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback PhotoTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer PhotoTimer = new Timer(PhotoTCB, PhotoParser, 0, 3600000);   //будем получать новости каждый час
            #endregion

            #region BTParser   
            ParserWorker<string[]> BTParser = new ParserWorker<string[]>(new BTParser());
            BTParser.OnCompleted += BTCommand.Parser_OnCompleted;
            BTParser.OnNewData += BTCommand.Parser_OnNewData;
            BTParser.Settings = new BTSettings(1, 1);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback BTTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer BTTimer = new Timer(BTTCB, BTParser, 0, 3600000);   //будем получать новости каждый час
            #endregion

            #region GorodParser   
            ParserWorker<string[]> GorodParser = new ParserWorker<string[]>(new GorodParser());
            GorodParser.OnCompleted += GorodCommand.Parser_OnCompleted;
            GorodParser.OnNewData += GorodCommand.Parser_OnNewData;
            GorodParser.Settings = new GorodSettings(1, 1);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем

            TimerCallback GorodTCB = new TimerCallback(GetNewsUpdate);	// устанавливаем метод обратного вызова
            // создаем таймер
            Timer GorodTimer = new Timer(GorodTCB, GorodParser, 0, 3600000);   //будем получать новости каждый час
            #endregion

            //TimerCallback tcb2 = new TimerCallback(GetLentaNews);	// устанавливаем метод обратного вызова
            //// создаем таймер
            //Timer timer2 = new Timer(tcb2, null, 0, 3000);   //будем отправлять сообщение в группу каждую минуту
            try
            {
                bot.RunAsync().Wait();
            }
            catch (AggregateException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                bot.RunAsync().Wait();
            }
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

