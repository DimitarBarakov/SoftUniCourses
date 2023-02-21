using System;

namespace _07._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n,n];
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                char[] el = input.ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row,col] = el[col];
                }
            }

            int counter = 0;
            int mostAtacked = 0;
            int mostAtackedRow = 0;
            int mostAtackedCol = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    int atacks = 0;
                    if (matrix[row,col] == 'K')
                    {
                        //one vertically down
                        if (row + 1 < matrix.GetLength(0))
                        {
                            if (col + 2 < matrix.GetLength(1))
                            {
                                if (matrix[row + 1, col + 2] == 'K')
                                {
                                    atacks++;
                                }
                            }
                            if (col - 2 >= 0)
                            {
                                if (matrix[row + 1, col - 2] == 'K')
                                {
                                    atacks++;
                                }
                            }
                        }
                        //one vertically up
                        if (row - 1 >= 0)
                        {
                            if (col + 2 < matrix.GetLength(1))
                            {
                                if (matrix[row - 1, col + 2] == 'K')
                                {
                                    atacks++;
                                }
                            }
                            if (col - 2 >= 0)
                            {
                                if (matrix[row - 1, col - 2] == 'K')
                                {
                                    atacks++;
                                }
                            }
                        }
                        //two vertically down
                        if (row + 2 < matrix.GetLength(0))
                        {
                            if (col + 1 < matrix.GetLength(1))
                            {
                                if (matrix[row + 2, col + 1] == 'K')
                                {
                                    atacks++;
                                }
                            }
                            if (col - 1 >= 0)
                            {
                                if (matrix[row + 2, col - 1] == 'K')
                                {
                                    atacks++;
                                }
                            }
                        }
                        // two vertically up
                        if (row - 2 >= 0)
                        {
                            if (col + 1 < matrix.GetLength(1))
                            {
                                if (matrix[row - 2, col + 1] == 'K')
                                {
                                    atacks++;
                                }
                            }
                            if (col - 1 >= 0)
                            {
                                if (matrix[row - 2, col - 1] == 'K')
                                {
                                    atacks++;
                                }
                            }
                        }
                    }
                    if (atacks > mostAtacked)
                    {
                        mostAtacked = atacks;
                        mostAtackedCol = col;
                        mostAtackedRow = row;
                    }
                }
                if (row == n-1 && mostAtacked>0)
                {
                    matrix[mostAtackedRow, mostAtackedCol] = '0';
                    mostAtacked = 0;
                    row = 0;
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
