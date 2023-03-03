using System;
using System.Linq;

namespace Survivor
{

    internal class Program
    {
        public int opponentTokens = 0;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] beach = new char[n][];
            for (int row = 0; row < n; row++)
            {
                beach[row] = Console.ReadLine().Split().Select(char.Parse).ToArray();
            }

            int collectedTokens = 0;
            int opponentTokens = 0;

            string cmd;
            while ((cmd = Console.ReadLine()) != "Gong")
            {
                string[] tokens = cmd.Split();
                string action = tokens[0];
                if (action == "Find")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    if (IsValid(row, col, beach))
                    {
                        if (beach[row][col] == 'T')
                        {
                            collectedTokens++;
                            beach[row][col] = '-';
                        }
                    }
                }
                else
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    string direction = tokens[3];
                    if (IsValid(row, col, beach))
                    {
                        if (beach[row][col] == 'T')
                        {
                            opponentTokens++;
                            beach[row][col] = '-';
                        }
                        int startRow = row;
                        int startCol = col;
                        int endRow = 0;
                        int endCol = 0;
                        if (direction == "up")
                        {
                            endRow = startRow - 3;
                            if (endRow < 0)
                            {
                                endRow = 0;
                            }
                            for (int rowIndex = startRow; rowIndex >= endRow; rowIndex--)
                            {
                                if (beach[rowIndex][col] == 'T')
                                {
                                    opponentTokens++;
                                    beach[rowIndex][col] = '-';
                                }
                            }
                        }
                        else if (direction == "down")
                        {
                            endRow = startRow + 3;
                            if (endRow >= beach.Length)
                            {
                                endRow = beach.Length - 1;
                            }
                            for (int rowIndex = startRow; rowIndex <= endRow; rowIndex++)
                            {
                                if (beach[rowIndex][col] == 'T')
                                {
                                    opponentTokens++;
                                    beach[rowIndex][col] = '-';
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            endCol = startCol - 3;
                            if (endCol < 0)
                            {
                                endCol = 0;
                            }
                            for (int colIndex = startCol; colIndex >= endCol; colIndex--)
                            {
                                if (beach[row][colIndex] == 'T')
                                {
                                    opponentTokens++;
                                    beach[row][colIndex] = '-';
                                }

                            }
                        }
                        else if (direction == "right")
                        {
                            endCol = startCol + 3;
                            if (endCol >= beach[row].Length)
                            {
                                endCol = beach[row].Length - 1;
                            }
                            for (int colIndex = startCol; colIndex <= endCol; colIndex++)
                            {
                                if (beach[row][colIndex] == 'T')
                                {
                                    opponentTokens++;
                                    beach[row][colIndex] = '-';
                                }

                            }
                        }
                    }
                }
            }

            //print
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < beach[row].Length; col++)
                {
                    Console.Write(beach[row][col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        public static bool IsValid(int row, int col, char[][] beach)
        {
            if (((row >= 0) && (row < beach.Length)) && ((col >= 0) && (col < beach[row].Length)))
            {
                return true;
            }
            return false;
        }

        public static int Opponent(int row, int col, string direction, char[][] beach)
        {
            int opponentTokens = 0;
            if (IsValid(row, col, beach))
            {
                if (beach[row][col] == 'T')
                {
                    opponentTokens++;
                    beach[row][col] = '-';
                }
                int startRow = row;
                int startCol = col;
                int endRow = 0;
                int endCol = 0;
                if (direction == "up")
                {
                    endRow = startRow - 3;
                    if (endRow < 0)
                    {
                        endRow = 0;
                    }
                    for (int rowIndex = startRow; rowIndex >= endRow; rowIndex--)
                    {
                        if (beach[rowIndex][col] == 'T')
                        {
                            opponentTokens++;
                            beach[rowIndex][col] = '-';
                        }
                    }
                }
                else if (direction == "down")
                {
                    endRow = startRow + 3;
                    if (endRow >= beach[row].Length)
                    {
                        endRow = beach[row].Length - 1;
                    }
                    for (int rowIndex = startRow; rowIndex <= endRow; rowIndex++)
                    {
                        if (beach[rowIndex][col] == 'T')
                        {
                            opponentTokens++;
                            beach[rowIndex][col] = '-';
                        }
                    }
                }
                else if (direction == "left")
                {
                    endCol = startCol - 3;
                    if (endCol < 0)
                    {
                        endRow = 0;
                    }
                    for (int colIndex = startCol; colIndex >= endCol; colIndex--)
                    {
                        if (beach[row][colIndex] == 'T')
                        {
                            opponentTokens++;
                            beach[row][colIndex] = '-';
                        }
                        
                    }
                }
                else if (direction == "right")
                {
                    endCol = startCol + 3;
                    if (endCol >= beach[row].Length)
                    {
                        endCol = beach[row].Length - 1;
                    }
                    for (int colIndex = startCol; colIndex <= endCol; colIndex++)
                    {
                        if (beach[row][colIndex] == 'T')
                        {
                            opponentTokens++;
                            beach[row][colIndex] = '-';
                        }

                    }
                }
            }
            return opponentTokens;
        }
    }
}