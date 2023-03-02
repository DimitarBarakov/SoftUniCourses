using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class Box<t>
    {
        private t value;

        public Box(t value)
        {
            this.value = value;
        }
        public string ToString()
        {
            return $"{typeof(t)}: {this.value}";
        }
    }
}
