using System;
using System.Linq;
using System.Text.RegularExpressions;
using BirthdayzBot.Models;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;
namespace BirthdayzBot.Commands
{
    public class HelpCommand : BaseBotCommand
    {
        private readonly BirthdayzContext _dbContext;

        private Models.User _user;

        private Models.Chat _chat;

        public override string Name => _commandName;

        private static readonly string _commandName = "help";

        public HelpCommand(Update update, string args = null)
            : base(update, args)
        {
            _dbContext = new BirthdayzContext();
        }

        public override RequestBase<Message> GetResponse()
        {
            string responseText;

            if (string.IsNullOrWhiteSpace(Args))
            {
                responseText = "mybd command lets you look at at your own birthday only if you have set your birthday./n" +
                     "If you want to add your birthday use /mybd jan 1 or mybd jan 1 93./n" +
                     "The bdz command gives you a list of birthdays that have been added to the database";
            }
            else if (string.Equals(Args, "mybd"))
            {
                responseText = "mybd command lets you look at at your own birthday only if you have set your birthday./n" +
                     "If you want to add your birthday use /mybd jan 1 or mybd jan 1 93.";
            }
            else if (string.Equals(Args, "bdz"))
            {
                responseText = "The bdz command gives you a list of birthdays that have been added to the database";
            }
            else
            {
                responseText = "Invalid command, try '/help', '/help mybd' or '/help bdz' ";
            }

            return new SendMessage(Update.Message.Chat.Id, responseText)
            {
                DisableNotification = true,
                ReplyToMessageId = Update.Message.MessageId,
                ParseMode = SendMessage.ParseModeEnum.Markdown,
            };

        }
    }
}
    
