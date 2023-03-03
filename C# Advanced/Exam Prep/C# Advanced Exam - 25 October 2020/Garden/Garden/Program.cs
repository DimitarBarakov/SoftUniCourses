using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = dimensions[0];
            int m = dimensions[1];

            int[,] garden = new int[n, m];
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    garden[row, col] = 0;
                }
            }

            Dictionary<int, int> flowers = new Dictionary<int, int>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] cordinates = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = cordinates[0];
                int col = cordinates[1];
                if ((row >= 0 && row < n) && (col >= 0 && col < m))
                {
                    flowers.Add(row, col);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            foreach (var flower in flowers)
            {
                int row = flower.Key;
                int col = flower.Value;
                for (int currCol = 0; currCol < m; currCol++)
                {
                    garden[row, currCol]++;
                }
                for (int currRow = 0; currRow < n; currRow++)
                {
                    if (currRow != row)
                    {
                        garden[currRow, col]++;
                    }
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    Console.Write(garden[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
