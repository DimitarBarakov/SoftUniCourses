using System;

namespace _07._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long[][] triangle = new long[n][];
            triangle[0] = new long[] { 1 };
            for (long row = 1; row < n; row++)
            {
                triangle[row] = new long[row + 1];
                triangle[row][0] = 1;
                for (long col = 1; col < row; col++)
                {
                    triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
                }
                triangle[row][row] = 1;
            }
            for (long row = 0; row < n; row++)
            {
                Console.WriteLine(String.Join(" ", triangle[row]));
            }
        }
    }
}
