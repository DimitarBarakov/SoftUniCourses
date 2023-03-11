using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLogger.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format { get => "{0} - {1} - {2}"; }
    }
}
