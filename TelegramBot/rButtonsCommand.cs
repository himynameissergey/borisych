using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot
{
    class rButtonsCommand : ICommand
    {
        /// <summary>
        /// Имя команды
        /// </summary>
        public string Name { get; set; } = "/rbuttons";
        /// <summary>
        /// Вызывает команду
        /// </summary>
        /// <param name="message">принимает сообщение</param>
        /// <param name="client">Ссылка на экземпляр бота</param>
        public async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            //reply кнопки
            var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
            {
                Keyboard = new[] {
                    new[] // row 1
                    {
                        new Telegram.Bot.Types.KeyboardButton("Чпоньк"),
                        new Telegram.Bot.Types.KeyboardButton("Жамк"),
                    },
                },
                ResizeKeyboard = true
            };
            await client.SendTextMessageAsync(chatId, "Жамкни внизу!", replyMarkup: keyboard);

            // обработка reply кнопок
            //client.OnUpdate += async (object sender, Telegram.Bot.Args.UpdateEventArgs evu) =>
            //{
                if (message.Text == "Чпоньк")
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "Ты нажал на первую кнопку!", replyToMessageId: message.MessageId);
                }
                if (message.Text == "Жамк")
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "Ты нажал на вторую кнопку!", replyToMessageId: message.MessageId);
                }
            //};
        }

    }
}
