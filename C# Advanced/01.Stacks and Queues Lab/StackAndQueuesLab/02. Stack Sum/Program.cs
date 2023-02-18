using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>(nums);
            string cmd;
            while ((cmd = Console.ReadLine().ToLower()) != "end")
            {
                string[] tokens = cmd.Split();
                string action = tokens[0];
                if (action == "add")
                {
                    int firstNum = int.Parse(tokens[1]);
                    int secondNum = int.Parse(tokens[2]);
                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else if (action == "remove")
                {
                    int count = int.Parse(tokens[1]);
                    if (stack.Count > count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }
            Console.WriteLine("Sum: " + stack.Sum());    
        }
    }
}
