using SoftUniLogger.Enums;
using SoftUniLogger.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.Messages
{
    public class Message : IMEssages
    {
        private const string NullArgumentMessage = "Argument cannot be empty"; 

        private string logTime;
        private string messageText;

        public Message(string logTime, string message, ReportLevel level)
        {
            this.LogTime = logTime;
            this.Level = level;
            this.MessageText = message;
        }
        public string LogTime 
        {
            get 
            {
                return this.logTime;
            }
            private set
            {
                if (!IsValidDateTime(value))
                {
                    throw new InvalidDateTimeFormatException();
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.LogTime), NullArgumentMessage);
                }
                this.logTime = value;
            }
        }

        public string MessageText 
        {
            get
            {
                return this.messageText;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.MessageText), NullArgumentMessage);
                }
                this.messageText = value;
            }
        }

        public ReportLevel Level { get; }

        private bool IsValidDateTime(string text) => DateTime.TryParse(text, out DateTime date);
    }
}
