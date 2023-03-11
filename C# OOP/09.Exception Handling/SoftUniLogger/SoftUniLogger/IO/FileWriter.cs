using SoftUniLogger.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.IO
{
    public class FileWriter : IFileWriter
    {
        public string FilePath => throw new NotImplementedException();

        public void WriteContent(string content, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
