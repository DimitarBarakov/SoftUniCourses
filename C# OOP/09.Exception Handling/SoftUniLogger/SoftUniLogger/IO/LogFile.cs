using SoftUniLogger.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.IO
{
    public class LogFile : ILogFile
    {
        private readonly StringBuilder sbContent;
        public LogFile()
        {
            sbContent = new StringBuilder();
        }
        public int Size=>sbContent.Length;

        public string Content=>sbContent.ToString();

        public void SaveAs(string filename)
        {
            throw new NotImplementedException();
        }

        public void Write(string content)
        {
            sbContent.AppendLine(content);
        }
    }
}
