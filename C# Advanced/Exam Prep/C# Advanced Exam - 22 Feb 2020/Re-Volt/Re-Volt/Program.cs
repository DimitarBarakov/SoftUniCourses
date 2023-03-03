using System;

namespace Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] square = new char[size, size];
            int n = int.Parse(Console.ReadLine());

            int playerRow = 0;
            int playerCol = 0;
            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();
                char[] el = line.ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    square[row, col] = el[col];
                    if (square[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
           

            for (int i = 0; i < n; i++)
            {
                string direction = Console.ReadLine();
                if (direction == "up")
                {
                    square[playerRow, playerCol] = '-';
                    if (playerRow == 0)
                    {
                        playerRow = size - 1;
                    }
                    else
                    {
                        playerRow--;
                    }
                    if (square[playerRow, playerCol] == 'B')
                    {
                        if (playerRow == 0)
                        {
                            playerRow = size - 1;
                        }
                        else
                        {
                            playerRow--;
                        }
                    }
                    else if (square[playerRow, playerCol] == 'T')
                    {
                        if (playerRow == size - 1)
                        {
                            playerRow = 0;
                        }
                        else
                        {
                            playerRow++;
                        }
                    }
                    else if (square[playerRow, playerCol] == 'F')
                    {
                        square[playerRow, playerCol] = 'f';
                        Console.WriteLine("Player won!");
                        for (int row = 0; row < size; row++)
                        {
                            string line = "";
                            for (int col = 0; col < size; col++)
                            {
                                line += square[row, col];
                            }
                            Console.WriteLine(line);
                        }
                        return;
                    }
                    else
                    {
                        square[playerRow, playerCol] = 'f';
                    }
                }
                else if (direction == "down")
                {
                    square[playerRow, playerCol] = '-';
                    if (playerRow == size - 1)
                    {
                        playerRow = 0;
                    }
                    else
                    {
                        playerRow++;
                    }
                    if (square[playerRow, playerCol] == 'B')
                    {
                        if (playerRow == size - 1)
                        {
                            playerRow = 0;
                        }
                        else
                        {
                            playerRow++;
                        }
                    }
                    else if (square[playerRow, playerCol] == 'T')
                    {
                        if (playerRow == 0)
                        {
                            playerRow = size - 1;
                        }
                        else
                        {
                            playerRow--;
                        }
                    }
                    else if (square[playerRow, playerCol] == 'F')
                    {
                        square[playerRow, playerCol] = 'f';
                        Console.WriteLine("Player won!");
                        for (int row = 0; row < size; row++)
                        {

                            string line = "";
                            for (int col = 0; col < size; col++)
                            {
                                line += square[row, col];
                            }
                            Console.WriteLine(line);
                        }
                        return;
                    }
                    else
                    {
                        square[playerRow, playerCol] = 'f';
                    }
                }
                else if (direction == "left")
                {
                    square[playerRow, playerCol] = '-';
                    if (playerCol == 0)
                    {
                        playerCol = size - 1;
                    }
                    else
                    {
                        playerCol--;
                    }
                    if(square[playerRow, playerCol] == 'B')
                    {
                        if (playerCol == 0)
                        {
                            playerCol = size - 1;
                        }
                        else
                        {
                            playerCol--;
                        }
                    }
                    else if (square[playerRow, playerCol] == 'T')
                    {
                        if (playerCol == size - 1)
                        {
                            playerCol = 0;
                        }
                        else
                        {
                            playerCol++;
                        }
                    }
                    else if (square[playerRow, playerCol] == 'F')
                    {
                        square[playerRow, playerCol] = 'f';
                        Console.WriteLine("Player won!");
                        for (int row = 0; row < size; row++)
                        {
                            string line = "";
                            for (int col = 0; col < size; col++)
                            {
                                line += square[row, col];
                            }
                            Console.WriteLine(line);
                        }
                        return;
                    }
                    else
                    {
                        square[playerRow, playerCol] = 'f';
                    }
                }
                else if (direction == "right")
                {
                    square[playerRow, playerCol] = '-';
                    if (playerCol == size - 1)
                    {
                        playerCol = 0;
                    }
                    else
                    {
                        playerCol++;
                    }
                    if (square[playerRow, playerCol] == 'B')
                    {
                        if (playerCol == size - 1)
                        {
                            playerCol = 0;
                        }
                        else
                        {
                            playerCol++;
                        }
                    }
                    else if (square[playerRow, playerCol] == 'T')
                    {
                        if (playerCol == 0)
                        {
                            playerCol = size - 1;
                        }
                        else
                        {
                            playerCol--;
                        }
                    }
                    else if (square[playerRow, playerCol] == 'F')
                    {
                        square[playerRow, playerCol] = 'f';
                        Console.WriteLine("Player won!");
                        for (int row = 0; row < size; row++)
                        {
                            string line = "";
                            for (int col = 0; col < size; col++)
                            {
                                line += square[row, col];
                            }
                            Console.WriteLine(line);
                        }
                        return;
                    }
                    else
                    {
                        square[playerRow, playerCol] = 'f';
                    }
                }
            }

            Console.WriteLine("Player lost!");
            for (int row = 0; row < size; row++)
            {
                string line = "";
                for (int col = 0; col < size; col++)
                {
                    line += square[row, col];
                }
                Console.WriteLine(line);
            }
        }
    }
}
