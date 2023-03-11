using SoftUniLogger.Formaters.Interfaces;
using SoftUniLogger.Layouts;
using SoftUniLogger.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.Formaters
{
    public class MessageFormater : IMessgeFormater
    {
        public MessageFormater(ILayout layout, IMEssages message)
        {
            this.Layout = layout;
            this.Message = message;
        }
        public ILayout Layout { get; }

        public IMEssages Message { get; }

        public string FormatMessage()
        {
            return String.Format(this.Layout.Format, this.Message.LogTime, this.Message.Level.ToString(), this.Message.MessageText);
        }
    }
}
