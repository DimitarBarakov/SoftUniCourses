using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings:Stack<string>
    {
        public bool IsEmpty()
        {
            if (base.Count == 0)
            {
                return true;
            }
            return false;
        }

        public Stack<string> AddRange(List<string> collection)
        {
            foreach (string item in collection)
            {
                base.Push(item);
            }
            return this;
        }
    }
}
