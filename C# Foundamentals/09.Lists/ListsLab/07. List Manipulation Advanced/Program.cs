using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            bool hasChanged = false;
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] splittedCommand = command.Split();
                string action = splittedCommand[0];
                if (action == "Add")
                {
                    int number = int.Parse(splittedCommand[1]);
                    numbers.Add(number);
                    hasChanged = true;
                }
                else if (action == "Remove")
                {
                    int number = int.Parse(splittedCommand[1]);
                    numbers.Remove(number);
                    hasChanged = true;
                }
                else if (action == "RemoveAt")
                {
                    int index = int.Parse(splittedCommand[1]);
                    numbers.RemoveAt(index);
                    hasChanged = true;
                }
                else if (action == "Insert")
                {
                    int number = int.Parse(splittedCommand[1]);
                    int index = int.Parse(splittedCommand[2]);
                    numbers.Insert(index, number);
                    hasChanged = true;
                }
                else if (action == "Contains")
                {
                    int number = int.Parse(splittedCommand[1]);
                    if (numbers.Contains(number))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (action == "PrintEven")
                {
                    PrintEven(numbers);
                }
                else if (action == "PrintOdd")
                {
                    PrintOdd(numbers);
                }
                else if (action == "GetSum")
                {
                    Console.WriteLine(numbers.Sum());
                }
                else if (action == "Filter")
                {
                    string condition = splittedCommand[1];
                    int number = int.Parse(splittedCommand[2]);
                    Filter(numbers, condition, number);
                }
            }
            if (hasChanged)
            {
                Console.WriteLine(string.Join(' ', numbers));
            }
        }

        static void PrintEven(List<int> nums)
        {
            List<int> res = new List<int>();
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    res.Add(nums[i]);
                }
            }
            Console.WriteLine(String.Join(' ', res));
        }
        static void PrintOdd(List<int> nums)
        {
            List<int> res = new List<int>();
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 != 0)
                {
                    res.Add(nums[i]);
                }
            }
            Console.WriteLine(String.Join(' ', res));
        }

        static void Filter(List<int> numbers, string condition, int num)
        {
            List<int> res = new List<int>();
            if (condition == "<")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] < num)
                    {
                        res.Add(numbers[i]);
                    }
                }
            }
            else if (condition == ">")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] > num)
                    {
                        res.Add(numbers[i]);
                    }
                }
            }
            else if (condition == "<=")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] <= num)
                    {
                        res.Add(numbers[i]);
                    }
                }
            }
            else if (condition == ">=")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] >= num)
                    {
                        res.Add(numbers[i]);
                    }
                }
            }

            Console.WriteLine(string.Join(' ', res));
        }
    }
}
