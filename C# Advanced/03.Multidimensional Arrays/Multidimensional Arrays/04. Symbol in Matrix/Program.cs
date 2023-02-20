using System;
using System.Linq;

namespace _04._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //char[,] matrix = new char[n, n];
            //for (int row = 0; row < n; row++)
            //{
            //    char[] line = Console.ReadLine().Split(", ").Select(char.Parse).ToArray();
            //    for (int col = 0; col < n; col++)
            //    {
            //        matrix[row, col] = line[col];
            //    }
            //}
            string[] asd = new string[n];
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                asd[i] = input;
            }

            char search = char.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                if (asd[i].Contains(search))
                {
                    Console.WriteLine($"({i}, {asd[i].IndexOf(search)})");
                    return;
                }
            }
            Console.WriteLine($"{search} does not occur in the matrix");
        }
    }
}
