using System;
using System.Linq;

namespace SecondTry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] maze = new char[n][];
            int marioRow = 0;
            int marioCol = 0;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                maze[row] = input.ToCharArray();
                for (int col = 0; col < maze[row].Length; col++)
                {
                    if (maze[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }
            while (true)
            {
                char[] tokens = Console.ReadLine().Split().Select(char.Parse).ToArray();

                char direction = tokens[0];
                int enemyRow = tokens[1] - '0';
                int enemyCol = tokens[2] - '0';

                maze[enemyRow][enemyCol] = 'B';
                maze[marioRow][marioCol] = '-';
                switch (direction)
                {
                    case 'W': marioRow--; break;
                    case 'S': marioRow++; break;
                    case 'A': marioCol--; break;
                    case 'D': marioCol++; break;
                    default:
                        break;
                }
                lives--;
                if (AreCordinatesValid(marioRow,marioCol,maze))
                {
                    if (maze[marioRow][marioCol] == 'B')
                    {
                        lives -= 2;
                        if (lives > 0)
                        {
                            maze[marioRow][marioCol] = 'M';
                        }
                        else
                        {
                            maze[marioRow][marioCol] = 'X';
                            Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                            break;
                        }
                    }
                    else if (maze[marioRow][marioCol] == 'P')
                    {
                        maze[marioRow][marioCol] = '-';
                        Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                        break;
                    }
                    else
                    {
                        maze[marioRow][marioCol] = 'M';
                    }
                }
            }
            for (int row = 0; row < n; row++)
            {
                string line = "";
                for (int col = 0; col < n; col++)
                {
                    line += maze[row][col];
                }
                Console.WriteLine(line);
            }
        }

        static bool AreCordinatesValid(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }
    }
}
