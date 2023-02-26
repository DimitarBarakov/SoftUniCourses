using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> add = x => x + 1;

            Func<int, int> subtract = x => x - 1;

            Func<int, int> multiply = x => x * 2;

            Action<List<int>> print = x=> Console.WriteLine(String.Join(" ", x));

            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string cmd;
            while ((cmd = Console.ReadLine()) != "end")
            {
                switch (cmd)
                {
                    case "add":
                        nums = nums.Select(add).ToList(); break;
                    case "subtract":
                        nums = nums.Select(subtract).ToList(); break;
                    case "multiply":
                        nums = nums.Select(multiply).ToList(); break;
                    case "print":
                        print(nums); break;
                    default:
                        break;
                }
            }
        }
        

        
    }
}
