using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    class iButtonsCommand : ICommand
    {
        /// <summary>
        /// Имя команды
        /// </summary>
        public string Name { get; set; } = "/ibuttons";
        /// <summary>
        /// Вызывает команду
        /// </summary>
        /// <param name="message">принимает сообщение</param>
        /// <param name="client">Ссылка на экземпляр бота</param>
        public async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            //var keyboard = new InlineKeyboardMarkup
            //(
            //    new InlineKeyboardButton[][]
            //    {
            //    // First row
            //        new InlineKeyboardButton[] 
            //        {
            //            // First column
            //            InlineKeyboardButton.WithCallbackData("one","callback1"),
            //            // Second column
            //            InlineKeyboardButton.WithCallbackData("two","callback2"),
            //        },
            //    }
            //);
            var keyboard = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(new[]
{
                new [] // first row
                {
                    InlineKeyboardButton.WithUrl("1.1","www.pornhub.com"),
                    InlineKeyboardButton.WithCallbackData("1.2", "callback1"),
                },
                new [] // second row
                {
                    InlineKeyboardButton.WithCallbackData("2.1", "callback2"),
                    InlineKeyboardButton.WithCallbackData("2.2"),
                }
            });

            await client.SendTextMessageAsync(chatId, "Жамкни!", replyMarkup: keyboard);

            client.OnCallbackQuery += async (object sender, Telegram.Bot.Args.CallbackQueryEventArgs ev) =>
            {
                var CBQMessage = ev.CallbackQuery.Message;
                if (ev.CallbackQuery.Data == "callback1")
                {
                    await client.AnswerCallbackQueryAsync(ev.CallbackQuery.Id, "Ты выбрал " + ev.CallbackQuery.Data, true);
                }
                else
                if (ev.CallbackQuery.Data == "callback2")
                {
                    await client.SendTextMessageAsync(CBQMessage.Chat.Id, "тест", replyToMessageId: CBQMessage.MessageId);
                    await client.AnswerCallbackQueryAsync(ev.CallbackQuery.Id); // отсылаем пустое, чтобы убрать "часики" на кнопке
                }
            };
        }
    }
}
