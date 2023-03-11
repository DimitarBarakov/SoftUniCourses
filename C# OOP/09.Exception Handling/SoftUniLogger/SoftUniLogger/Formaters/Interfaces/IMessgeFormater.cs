using SoftUniLogger.Layouts;
using SoftUniLogger.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.Formaters.Interfaces
{
    public interface IMessgeFormater
    {
        ILayout Layout { get; }
        IMEssages Message { get; }
        public string FormatMessage();
    }
}
