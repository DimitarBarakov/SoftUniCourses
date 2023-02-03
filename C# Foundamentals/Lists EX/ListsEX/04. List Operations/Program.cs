using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                if (action == "Add")
                {
                    int number = int.Parse(tokens[1]);
                    numbers.Add(number);
                }
                else if (action == "Insert")
                {
                    int number = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    if (index < 0 || index >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(index, number);
                    }
                    
                }
                else if (action == "Remove")
                {
                    int index = int.Parse(tokens[1]);
                    if (index < 0 || index >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else 
                    {
                        numbers.RemoveAt(index);
                    }
                    
                }
                else if (action == "Shift")
                {
                    string direction = tokens[1];
                    int count = int.Parse(tokens[2]);
                    if (direction == "left")
                    {
                        ShiftLeft(numbers, count);
                    }
                    else
                    {
                        ShiftRight(numbers, count);
                    }
                }
            }
            Console.WriteLine(string.Join(' ', numbers));
        }

        static List<int> ShiftLeft(List<int> numbers, int rotations)
        {
            for (int i = 0; i < rotations; i++)
            {
                for (int j = 0; j < numbers.Count - 1; j++)
                {
                    int temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                }
            }
            return numbers;
        }

        static List<int> ShiftRight(List<int> numbers, int rotations)
        {
            for (int i = 0; i < rotations; i++)
            {
                for (int j = numbers.Count - 1; j > 0; j--)
                {
                    int temp = numbers[j];
                    numbers[j] = numbers[j - 1];
                    numbers[j - 1] = temp;
                }
            }
            return numbers;

        }
    }
}
