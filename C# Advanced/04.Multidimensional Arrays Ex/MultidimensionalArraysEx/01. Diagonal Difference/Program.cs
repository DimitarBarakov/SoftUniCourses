using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n,n];

            for (int i = 0; i < n; i++)
            {
                int[] colEl = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int k = 0; k < n; k++)
                {
                    matrix[i, k] = colEl[k];
                }
            }

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int i = 0; i < n; i++)
            {
                primaryDiagonalSum+=matrix[i,i];
            }

            int j = n;
            for (int i = 0; i < n; i++)
            {
                j--;
                secondaryDiagonalSum+=matrix[i,j];
            }
            Console.WriteLine(Math.Abs(primaryDiagonalSum-secondaryDiagonalSum));
        }
    }
}
