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
    class TalkCommand : ICommand
    {
        static List<string> lines = ReadingTextFile.GetLinesOfTextFile();

        //public string Name { get; set; } = "борисыч";
        public string Name { get; set; } = lines[2];
        public async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            DateTime now = DateTime.Now;
            string phrase = Generate(1);
            await client.SendTextMessageAsync(chatId, phrase);//, replyToMessageId: messageId);
            Bot.ConsoleWriteLog(message);
        }
        public string Generate(int numMessages)
        {
            //string path = @"..\..\phrases.txt";
            string path = @"phrases.txt";
            string[] lines = new string[100];
            int i = 0;  // счетчик для цикла
            int linesCount = 0; // // количество строк в файле
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    while ((lines[i] = sr.ReadLine()) != null)
                    {
                        i++;
                    }
                    linesCount = i; // количество строк в файле
                }
            }
            catch (Exception exept)
            {
                Console.WriteLine(exept.Message);
            }

            Random rnd = new Random();
            int n = rnd.Next(linesCount);  // случайным образом выбираем фразу из файла     
            
            return lines[n];
        }

        //public string[] s = {
        //    "Ну привет",
        //    "Я с тобой не разговариваю",
        //    "Нет, я не обиделся",
        //    "Да пошел ты",
        //    "Отвали",
        //    "Что случилось?",
        //    "Ублюдок, мать твою, а ну иди сюда, говно собачье",
        //    "Я занят",
        //    "Займись делом",
        //    "Мне сейчас типа некогда",
        //    "Я слушаю",
        //    "Внимательно",
        //    "Че надо?",
        //    "Ну ты и опездол",
        //    "Как же вы меня достали!",
        //    "Не надоело еще?",
        //    "Как же тяжело работать с кретинами!",
        //    "Ты спятил?",
        //    "Я твой дом труба шатал",
        //    "Я устал с тобой общаться"
        //};
    }

}
