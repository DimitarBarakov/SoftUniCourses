using System;
using System.Collections;

namespace zad1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Stack stack = new Stack();
            foreach (var el in text)
            {
                stack.Push(el);
            }
            while (stack.Count>0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
