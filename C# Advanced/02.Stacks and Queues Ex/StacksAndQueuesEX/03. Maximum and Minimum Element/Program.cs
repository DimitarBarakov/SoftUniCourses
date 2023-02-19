using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> nums = new Stack<int>();
            int n = int.Parse(Console.ReadLine());
            string cmd;
            for (int i = 0; i < n; i++)
            {
                cmd = Console.ReadLine();
                string[] tokens = cmd.Split(' ');
                int action = int.Parse(tokens[0]);
                if (action == 1)
                {
                    int num = int.Parse(tokens[1]);
                    nums.Push(num);
                }
                else if (action == 2)
                {
                    if (nums.Count > 0)
                    {
                        nums.Pop();
                    }
                }
                else if (action == 3)
                {
                    if (nums.Count>0)
                    {
                        Console.WriteLine(nums.Max());
                    }
                }
                else if (action == 4)
                {
                    if (nums.Count > 0)
                    {
                        Console.WriteLine(nums.Min());
                    }
                }
            }
            Console.WriteLine(String.Join(", ", nums));
        }
    }
}
