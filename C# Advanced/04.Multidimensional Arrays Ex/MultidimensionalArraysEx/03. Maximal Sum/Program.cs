using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];
            int[,] matrix = new int[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            int maxSum = 0;
            int bestElementRow = 0;
            int bestElementCol = 0;
            for (int row = 0; row < rowsCount - 2; row++)
            {
                for (int col = 0; col < colsCount - 2; col++)
                {
                    int currSum = 0;
                    currSum += matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        bestElementCol = col;
                        bestElementRow = row;
                    }
                }
            }
            Console.WriteLine("Sum = " + maxSum);
            Console.WriteLine(matrix[bestElementRow, bestElementCol] + " " + matrix[bestElementRow, bestElementCol + 1] + " " + matrix[bestElementRow, bestElementCol + 2]);
            Console.WriteLine(matrix[bestElementRow + 1, bestElementCol] + " " + matrix[bestElementRow + 1, bestElementCol + 1] + " " + matrix[bestElementRow + 1, bestElementCol + 2]);
            Console.WriteLine(matrix[bestElementRow + 2, bestElementCol] + " " + matrix[bestElementRow + 2, bestElementCol + 1] + " " + matrix[bestElementRow + 2, bestElementCol + 2]);
        }
    }
}
