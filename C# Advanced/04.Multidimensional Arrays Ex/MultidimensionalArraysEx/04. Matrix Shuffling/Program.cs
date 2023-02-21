using System;
using System.Linq;

namespace _04._Matrix_Shuffling
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

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] tokens = cmd.Split();
                if (tokens.Length != 5 || tokens[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int row1 = int.Parse(tokens[1]);
                    int col1 = int.Parse(tokens[2]);
                    int row2 = int.Parse(tokens[3]);
                    int col2 = int.Parse(tokens[4]);
                    if ((row1 < 0 || row1 >= rowsCount) || (row2 < 0 || row2 >= rowsCount) || (col1 < 0 || col1 >= colsCount) || (col2 < 0 || col2 >= colsCount))
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        string firstEl = matrix[row1, col1];
                        string secondEl = matrix[row2, col2];

                        string temp = firstEl;
                        firstEl = secondEl;
                        secondEl = temp;

                        matrix[row1, col1] = firstEl;
                        matrix[row2, col2] = secondEl;
                        for (int row = 0; row < rowsCount; row++)
                        {
                            for (int col = 0; col < colsCount; col++)
                            {
                                Console.Write(matrix[row,col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}