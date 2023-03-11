using System;
using System.Collections.Generic;

namespace _02._Enter_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            while (numbers.Count < 10)
            {
                try
                {
                    int a;
                    if (numbers.Count == 0)
                    {
                        a = ReadNumber(1, 100);
                    }
                    else
                    {
                        a = ReadNumber(numbers[numbers.Count - 1], 100);
                    }
                    numbers.Add(a);
                }
                catch (ArgumentOutOfRangeException)
                {
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine($"Your number is not in range 1 - 100!");
                    }
                    else
                    {
                        Console.WriteLine($"Your number is not in range {numbers[numbers.Count - 1]} - 100!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
            }
            Console.WriteLine(String.Join(", ", numbers));
        }

        public static int ReadNumber(int start, int end)
        {
            int a = int.Parse(Console.ReadLine());
            if (a <= start || a >= end)
            {
                throw new ArgumentOutOfRangeException("ads");
            }
            return a;
        }
    }
}
