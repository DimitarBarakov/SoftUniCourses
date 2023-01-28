using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] splittedCommand = command.Split();
                string action = splittedCommand[0];
                if (action == "Add")
                {
                    int number = int.Parse(splittedCommand[1]);
                    numbers.Add(number);
                }
                else if (action == "Remove")
                {
                    int number = int.Parse(splittedCommand[1]);
                    numbers.Remove(number);
                }
                else if (action == "RemoveAt")
                {
                    int index = int.Parse(splittedCommand[1]);
                    numbers.RemoveAt(index);
                }
                else if (action == "Insert")
                {
                    int number = int.Parse(splittedCommand[1]);
                    int index = int.Parse(splittedCommand[2]);
                    numbers.Insert(index, number);
                }
            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
