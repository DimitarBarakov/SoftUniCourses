using System;
using System.Linq;

namespace SuperMario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            if (n == 0)
            {
                return;
            }
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
                string[] tokens = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

                string direction = tokens[0];
                int enemyRow = int.Parse(tokens[1]);
                int enemyCol = int.Parse(tokens[2]);

                maze[enemyRow][enemyCol] = 'B';

                if (direction == "W")
                {
                    if (marioRow == 0)
                    {
                        lives--;
                    }
                    else
                    {
                        lives--;
                        maze[marioRow][marioCol] = '-';
                        marioRow--;
                    }

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
                else if (direction == "S")
                {
                    if (marioRow == n-1)
                    {
                        lives--;
                    }
                    else
                    {
                        lives--;
                        maze[marioRow][marioCol] = '-';
                        marioRow++;
                    }

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
                else if (direction == "A")
                {
                    if (marioCol == 0)
                    {
                        lives--;
                    }
                    else
                    {
                        lives--;
                        maze[marioRow][marioCol] = '-';
                        marioCol--;
                    }

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
                if (direction == "D")
                {
                    if (marioCol == n-1)
                    {
                        lives--;
                    }
                    else
                    {
                        lives--;
                        maze[marioRow][marioCol] = '-';
                        marioCol++;
                    }

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
    }
}
