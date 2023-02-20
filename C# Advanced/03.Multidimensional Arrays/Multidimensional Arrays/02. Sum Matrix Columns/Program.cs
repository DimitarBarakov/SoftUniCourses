using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
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
                int[] line = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
            for (int col = 0; col < colsCount; col++)
            {
                int colsum = 0;
                for (int row = 0; row < rowsCount; row++)
                {
                    colsum+=matrix[row, col];   
                }
                Console.WriteLine(colsum);
            }
        }
    }
}
