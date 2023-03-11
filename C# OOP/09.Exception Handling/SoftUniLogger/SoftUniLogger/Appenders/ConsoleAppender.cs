using SoftUniLogger.Formaters.Interfaces;
using SoftUniLogger.Formaters;
using SoftUniLogger.Layouts;
using SoftUniLogger.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private ConsoleAppender()
        {
            this.Count = 0;
        }
        public ConsoleAppender(ILayout layout):this()
        {
            this.Layout = layout;
        }
        public int Count { get; private set; }

        public ILayout Layout { get; }

        public void Append(IMEssages message)
        {
            IMessgeFormater messgeFormater = new MessageFormater(this.Layout, message);
            Console.WriteLine(messgeFormater.FormatMessage());
            Count++;
        }

        
          
    }
}
