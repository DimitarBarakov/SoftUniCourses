using SoftUniLogger.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.Messages
{
    public interface IMEssages
    {
        string LogTime { get; }
        
        string MessageText { get; }

        ReportLevel Level { get; }
    }
}
