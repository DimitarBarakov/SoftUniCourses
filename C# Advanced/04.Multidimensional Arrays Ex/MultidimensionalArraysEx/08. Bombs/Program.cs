using System;
using System.Linq;

namespace _08._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                int[] el = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < el.Length; col++)
                {
                    matrix[row, col] = el[col];
                }
            }
            string[] input = Console.ReadLine().Split();
            for (int i = 0; i < input.Length; i++)
            {
                int[] cordinates = input[i].Split(',').Select(int.Parse).ToArray();
                int row = cordinates[0];
                int col = cordinates[1];
                int bombValue = matrix[row, col];
                if (bombValue > 0)
                {
                    if (row - 1 >= 0 && col - 1 >= 0)
                    {
                        if (matrix[row - 1, col - 1] > 0)
                        {
                            matrix[row - 1, col - 1] -= bombValue;
                        }
                    }
                    if (row - 1 >= 0)
                    {
                        if (matrix[row - 1, col] > 0)
                        {
                            matrix[row - 1, col] -= bombValue;
                        }
                    }
                    if (row - 1 >= 0 && col + 1 < n)
                    {
                        if (matrix[row - 1, col + 1] > 0)
                        {
                            matrix[row - 1, col + 1] -= bombValue;
                        }
                    }
                    if (col - 1 >= 0)
                    {
                        if (matrix[row, col - 1] > 0)
                        {
                            matrix[row, col - 1] -= bombValue;
                        }
                    }
                    if (col + 1 < n)
                    {
                        if (matrix[row, col + 1] > 0)
                        {
                            matrix[row, col + 1] -= bombValue;
                        }
                    }
                    if (row + 1 < n && col - 1 >= 0)
                    {
                        if (matrix[row + 1, col - 1] > 0)
                        {
                            matrix[row + 1, col - 1] -= bombValue;
                        }
                    }
                    if (row + 1 < n)
                    {
                        if (matrix[row + 1, col] > 0)
                        {
                            matrix[row + 1, col] -= bombValue;
                        }
                    }
                    if (row + 1 < n && col + 1 < n)
                    {
                        if (matrix[row + 1, col + 1] > 0)
                        {
                            matrix[row + 1, col + 1] -= bombValue;
                        }
                    }
                }
                matrix[row, col] = 0;
            }
            int aliveCellsCounter = 0;
            int aliveCellsSum = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row,col] > 0)
                    {
                        aliveCellsCounter++;
                        aliveCellsSum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine("Alive cells: " + aliveCellsCounter);
            Console.WriteLine("Sum: " + aliveCellsSum);
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
