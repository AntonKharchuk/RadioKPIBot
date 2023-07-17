using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Polling;
using RadioKPIBot.DataAccess.Repository.IRepository;
using Telegram.Bot.Types.ReplyMarkups;
using System.Text.RegularExpressions;




namespace RadioKPIBot
{
    public class Bot
    {
        TelegramBotClient _botClient;
        BotMethods _botMethods;
        CancellationToken cancellationToken;
        ReceiverOptions receiverOptions;

        IUnitOfWork _unitOfWork;

        public Bot(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _botMethods = new BotMethods();
            _botClient = new TelegramBotClient("6184793493:AAFJsXtFVFikl8CLrs9GzqjV-uEwacpVGQ8");
            cancellationToken = new CancellationToken();
            receiverOptions = new ReceiverOptions { AllowedUpdates = { } };
        }
        public Bot()
        {
            
            _botMethods = new BotMethods();
            _botClient = new TelegramBotClient("6184793493:AAFJsXtFVFikl8CLrs9GzqjV-uEwacpVGQ8");
            cancellationToken = new CancellationToken();
            receiverOptions = new ReceiverOptions { AllowedUpdates = { } };
        }
        public async Task Start()
        {
            _botClient.StartReceiving(HandlerUpdateAsync, HandlerError, receiverOptions, cancellationToken);
            var botMe = await _botClient.GetMeAsync();
            Console.WriteLine($"Bot {botMe.Username} start working");


        }
        private Task HandlerError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Error in API {apiRequestException.ErrorCode}\n" + $"{apiRequestException.Message}",
                _ => exception.ToString()
            };
            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        private async Task HandlerUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {

            if (update.Type == UpdateType.Message && update.Message?.Text != null)
            {
                try
                {

                    await HandlerMessageAsync(botClient, update.Message);

                }
                catch (Exception e)
                {
                    await botClient.SendTextMessageAsync(update.Message.Chat.Id, e.Message);
                }

            }
            else if (update.Type == UpdateType.Message && update.Message?.Audio != null)
            {
                await HandlerAudioAsync(botClient, update.Message);
            }
        }

        private async Task HandlerAudioAsync(ITelegramBotClient botClient, Message message)
        {
            //foreach (var admin in _unitOfWork.Admin.GetAll())
            //{
            //    var markap = _botMethods.GetAdminChoiseMarkup(message.Audio.FileId);

            //    await botClient.SendAudioAsync(chatId: admin.UserId, InputFile.FromFileId(message.Audio.FileId));
            //}

            //var markap = _botMethods.GetAdminChoiseMarkup(message.Audio.FileId);
            var markap = _botMethods.GetAdminChoiseMarkup("haha");

            await botClient.SendAudioAsync(682314826, InputFile.FromFileId(message.Audio.FileId), replyMarkup: markap);

        }


        private async Task HandlerMessageAsync(ITelegramBotClient botClient, Message message)
        {
            
        }
    }
}
