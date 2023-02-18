using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] task = Console.ReadLine().Split(' ');
            task = task.Reverse().ToArray();
            Stack<string> stack = new Stack<string>(task);
            //foreach (string s in task)
            //{
            //    stack.Push(s);
            //}
            int sum = 0;
            sum += int.Parse(stack.Pop());
            while (stack.Count > 0)
            {
                string operation = stack.Pop();
                int currentNum = int.Parse(stack.Pop());
                if (operation == "+")
                {
                    sum += currentNum;
                }
                else if (operation == "-")
                {
                    sum-= currentNum;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
