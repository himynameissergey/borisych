using MihaZupan;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            List<string> lines = ReadingTextFile.GetLinesOfTextFile();

            //bot = new TelegramBotClient(BotSettings.Key);
            #region Proxy
            //var proxy = new HttpToSocks5Proxy("bot.avinfo17.info", 38157);
            //var proxy = new HttpToSocks5Proxy("18.231.190.109", 8080);
            //proxy.ResolveHostnamesLocally = true; // Allows you to use proxies that are only allowing connections to Telegram
            #endregion

            //bot = new TelegramBotClient(lines[1]);
            bot = new TelegramBotClient(lines[1]/*, proxy*/);
            commands.Add(new HelloCommand());
            commands.Add(new HelpCommand());
            commands.Add(new BredCommand());
            commands.Add(new TalkCommand());
            commands.Add(new AnekCommand());
            commands.Add(new ParseCommand()); //stavklass.ru
            commands.Add(new LentaCommand());
            commands.Add(new PikabuCommand());
            commands.Add(new _2chnCommand());
            commands.Add(new _2chbCommand());
            commands.Add(new PornCommand());
            commands.Add(new RedditCommand());
            commands.Add(new KMPCommand());
            commands.Add(new ArhivachCommand());
            commands.Add(new vkCommand());
            commands.Add(new PenCommand());
            commands.Add(new _9gagCommand());
            commands.Add(new BashCommand());
            commands.Add(new MsgCommand());
            commands.Add(new PhotoCommand());

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
            Console.WriteLine("" + DateTime.Now + " >> " + message.From.Id + " " + message.From.LastName + " " + message.From.FirstName + " >> " + message.Text);
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
                        foreach (var command in commands)
                        {
                            if (update.Message.Text != null && (update.Message.Text.ToLower().Contains(command.Name)))
                            {
                                command.Execute(update.Message, bot);
                                break;
                            }
                        }
                    }
                    offset = update.Id + 1;
                }
            }
        }
    }
}