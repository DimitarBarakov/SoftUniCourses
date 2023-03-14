using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int _min;
        private int _max;
        public MyRangeAttribute(int min, int max)
        {
            this._min = min;
            this._max = max;
        }

        public override bool IsValid(object obj)
        {
            int age = (int)obj;
            if (age >= this._min && age <= this._max)
            {
                return true;
            }
            return false;
        }
    }
}