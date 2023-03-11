using SoftUniLogger.Enums;
using SoftUniLogger.Layouts;
using SoftUniLogger.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.Appenders
{
    public interface IAppender
    {
        int Count { get; }

        ILayout Layout { get; }
        void Append(IMEssages message);
    }
}
