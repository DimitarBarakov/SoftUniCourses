﻿using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n,n];
            for (int row = 0; row < n; row++)
            {
                int[] line = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum+=matrix[i,i];
            }
            Console.WriteLine(sum);
        }
    }
}
