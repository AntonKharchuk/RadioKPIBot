using Newtonsoft.Json;
using RadioKPIBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace RadioKPIBot
{
    public class BotMethods
    {
        private InlineKeyboardButton GetButtonWithCallBackData(string text, CallBackData data)
        {
            var jsonCallBack = JsonConvert.SerializeObject(data);
            return InlineKeyboardButton.WithCallbackData(text, jsonCallBack);
        }

        public InlineKeyboardMarkup GetAdminChoiseMarkup(string id)
        {

            List<List<InlineKeyboardButton>> buttons = new List<List<InlineKeyboardButton>> { };

            CallBackData callBackAllow = new CallBackData()
            {
                Act = "AllowTreck",
                Value = id
            };
          
            CallBackData callBackNotAllow = new CallBackData()
            {
                Act = "NotAllowTreck",
                Value = id
            };

            buttons.Add(new List<InlineKeyboardButton>
                        {
                            GetButtonWithCallBackData("AllowTreck",callBackAllow),
                            GetButtonWithCallBackData("NotAllowTreck",callBackNotAllow)
                        }
            );

            InlineKeyboardMarkup keyboardMarkup = new InlineKeyboardMarkup
            (
            buttons
            );
            return keyboardMarkup;
        }


    }
}
