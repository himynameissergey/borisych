﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TelegramBot.ParserCore;
using TelegramBot.ParserCore.Habra;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot bot = new Bot();

            Console.WindowHeight = 10;
            Console.WindowWidth = 100;
            Console.Title = "Бот Борисыч для Telegram";
            Console.WriteLine(DateTime.Now+" Бот Борисыч запущен");

            #region For parsing           
            ParserWorker<string[]> parser;
            parser = new ParserWorker<string[]>(new HabraParser());
            parser.OnCompleted += ParseCommand.Parser_OnCompleted;
            parser.OnNewData += ParseCommand.Parser_OnNewData;
            parser.Settings = new HabraSettings(1, 1);  // первая страница сайта
            //parser.Start();   //при работе с таймером эту строчку закомментируем
            // устанавливаем метод обратного вызова
            TimerCallback tcb = new TimerCallback(Get2chNews);
            // создаем таймер
            Timer timer = new Timer(tcb, parser, 0, 3600000);   //будем получать новости каждый час
            #endregion

            bot.RunAsync().Wait();
            Console.ReadKey();
        }
        //получаем новые новости
        static void Get2chNews(object obj)
        {
            ParserWorker<string[]> parser = (ParserWorker<string[]>)obj;
            parser.Start();
            //Console.WriteLine("Текущее время:  " + DateTime.Now.ToLongTimeString());
        }
    }
}
