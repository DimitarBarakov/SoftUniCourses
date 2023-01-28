using System;

namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            if (a < b)
            {
                PrintElBetweenTwoCharacters(a, b);
            }
            else
            {
                PrintElBetweenTwoCharacters(b, a);
            }
        }

        static void PrintElBetweenTwoCharacters(char first, char second)
        {
            for (int i = first + 1; i < second; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
