using System;
using System.Linq;

namespace _02._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];
            string[,] matrix = new string[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                string[] elements = Console.ReadLine().Split();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            int equal2x2Square = 0;

            for (int row = 0; row < rowsCount - 1; row++)
            {
                for (int col = 0; col < colsCount - 1; col++)
                {
                    string currEl = matrix[row, col];
                    if (currEl == matrix[row, col + 1] && currEl == matrix[row + 1, col] && currEl == matrix[row + 1, col + 1])
                    {
                        equal2x2Square++;
                    }
                }
            }
            Console.WriteLine(equal2x2Square);
        }
    }
}
