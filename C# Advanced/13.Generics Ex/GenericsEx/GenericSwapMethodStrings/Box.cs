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


        public int Count(List<t> elements, t elementToCompare)
        {
            for (int i = 0; i < elements.Count; i++)
            {

            }
        }
        public string ToString()
        {
            return $"{typeof(t)}: {this.value}";
        }
    }
}
