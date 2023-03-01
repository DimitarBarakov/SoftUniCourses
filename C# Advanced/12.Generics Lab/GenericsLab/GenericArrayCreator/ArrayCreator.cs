using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static t[] Create<t>(int lenght, t item)
        {
            t[] result = new t[lenght];
            for (int i = 0; i < lenght; i++)
            {
                result[i] = item;
            }
            return result;
        }
    }
}
