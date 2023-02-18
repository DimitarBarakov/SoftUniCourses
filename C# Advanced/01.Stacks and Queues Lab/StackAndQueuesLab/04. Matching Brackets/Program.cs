using System;
using System.Collections.Generic;

namespace _04._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string exp = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '(')
                {
                    stack.Push(i);
                }
                else if (exp[i] == ')')
                {
                    int lastIndex = i;
                    int firstIndex = stack.Pop();
                    string substring = exp.Substring(firstIndex, lastIndex - firstIndex + 1);
                    Console.WriteLine(substring);
                }
            }
        }
    }
}
