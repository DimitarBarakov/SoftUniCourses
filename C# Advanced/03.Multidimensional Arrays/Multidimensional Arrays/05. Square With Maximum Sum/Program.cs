using System;
using System.Linq;

namespace _05._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arg = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rowsCount = arg[0];
            int colsCount = arg[1];
            int[,] matrix = new int[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                int[] line = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            int maxSum = 0;
            int bestSquareFirstElementRow = 0;
            int bestSquareFirstElementCol = 0;
            for (int row = 0; row < rowsCount - 1; row++)
            {
                for (int col = 0; col < colsCount - 1; col++)
                {
                    int currSum = 0;
                    currSum += matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (currSum > maxSum)
                    {
                        bestSquareFirstElementCol = col;
                        bestSquareFirstElementRow = row;
                        maxSum = currSum;
                    }
                }
            }
            Console.WriteLine(matrix[bestSquareFirstElementRow,bestSquareFirstElementCol]+" "+ matrix[bestSquareFirstElementRow, bestSquareFirstElementCol+1]);
            Console.WriteLine(matrix[bestSquareFirstElementRow + 1, bestSquareFirstElementCol]+" "+ matrix[bestSquareFirstElementRow+1, bestSquareFirstElementCol+1]);
            Console.WriteLine(maxSum);
        }
    }
}
