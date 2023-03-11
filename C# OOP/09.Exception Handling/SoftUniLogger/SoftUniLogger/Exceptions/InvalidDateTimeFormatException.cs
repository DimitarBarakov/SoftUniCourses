using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.Exceptions
{
    public class InvalidDateTimeFormatException:Exception
    {
        private const string DefaultMessage = "Provided DateTime is not in correct format!";
        public InvalidDateTimeFormatException():base(DefaultMessage)
        {

        }
    }
}
