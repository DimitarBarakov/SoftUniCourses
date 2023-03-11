using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.IO.Interfaces
{
    public interface ILogFile
    {
        int Size { get; }
        string Content { get; }

        void Write(string content);

        void SaveAs(string filename);
    }
}
