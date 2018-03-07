﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot
{
    class Bot
    {
        private TelegramBotClient bot;
        /// <summary>
        /// Создание списка команд для бота
        /// </summary>
        private static List<ICommand> commands = new List<ICommand>();
        /// <summary>
        /// Получить список команд
        /// </summary>
        public static List<ICommand> GetCommands
        {
            get
            {
                return commands;
            }
        }
        /// <summary>
        /// Создание бот-клиента, инициализация новых команд
        /// </summary>
        public Bot()
        {
            List<string> lines = ReadingTextFile.GetLinesOfTextFile(3);

            //bot = new TelegramBotClient(BotSettings.Key);
            bot = new TelegramBotClient(lines[1]);
            commands.Add(new HelloCommand());
            commands.Add(new HelpCommand());
            commands.Add(new BredCommand());
            commands.Add(new TalkCommand());
            commands.Add(new ParseCommand());
            //commands.Add(new iButtonsCommand());
            //commands.Add(new rButtonsCommand());
        }
        /// <summary>
        /// Функция возвращает строку с заглавным первым символом
        /// </summary>
        //string FirstSymbolUp(string str)
        //{
        //    return str.Substring(0, 1).ToUpper() + (str.Length > 1 ? str.Substring(1) : "");
        //}
        public static void ConsoleWriteLog(Message message)
        {
            Console.WriteLine("" + DateTime.Now + " >> " + message.From.LastName + " " + message.From.FirstName + " >> " + message.Text);
        }
        /// <summary>
        /// Запуск бота
        /// </summary>
        public async Task RunAsync()
        {
            int offset = 0;
            while (true)
            {
                var updates = await bot.GetUpdatesAsync(offset);

                foreach (var update in updates)
                {
                    if (update.Message != null) 
                    {
                        {
                            foreach (var command in commands)
                            {
                                if (update.Message.Text != null && (update.Message.Text.ToLower().Contains(command.Name)))
                                {
                                    command.Execute(update.Message, bot);
                                    break;
                                }
                            }
                        }
                    }
                    offset = update.Id + 1;
                }
            }
        }
    }
}
