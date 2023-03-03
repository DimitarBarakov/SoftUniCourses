using System;
using System.Linq;

namespace TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] forest = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                char[] el = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    forest[row, col] = el[col];
                }
            }
            int blackTruffleCount = 0;
            int summerTruffleCount = 0;
            int whiteTruffleCount = 0;
            int wildboarTruffleCount = 0;

            string cmd;
            while ((cmd = Console.ReadLine()) != "Stop the hunt")
            {
                string[] tokens = cmd.Split(" ");
                string action = tokens[0];
                if (action == "Collect")
                {
                    int rowIndex = int.Parse(tokens[1]);
                    int colIndex = int.Parse(tokens[2]);
                    char el = forest[rowIndex, colIndex];
                    switch (el)
                    {
                        case 'B': blackTruffleCount++; forest[rowIndex, colIndex] = '-'; break;
                        case 'S': summerTruffleCount++; forest[rowIndex, colIndex] = '-'; break;
                        case 'W': whiteTruffleCount++; forest[rowIndex, colIndex] = '-'; break;
                        default:
                            break;
                    }

                }
                else
                {
                    int rowIndex = int.Parse(tokens[1]);
                    int colIndex = int.Parse(tokens[2]);
                    string direction = tokens[3];
                    if (direction == "up")
                    {
                        for (int row = rowIndex; row >= 0; row -= 2)
                        {
                            if (forest[row, colIndex] == 'S' || forest[row, colIndex] == 'B' || forest[row, colIndex] == 'W')
                            {
                                wildboarTruffleCount++;
                                forest[row, colIndex] = '-';
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int row = rowIndex; row < n; row += 2)
                        {
                            if (forest[row, colIndex] == 'S' || forest[row, colIndex] == 'B' || forest[row, colIndex] == 'W')
                            {
                                wildboarTruffleCount++;
                                forest[row, colIndex] = '-';
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int col = colIndex; col >= 0; col -= 2)
                        {
                            if (forest[rowIndex, col] == 'S' || forest[rowIndex, col] == 'B' || forest[rowIndex, col] == 'W')
                            {
                                wildboarTruffleCount++;
                                forest[rowIndex, col] = '-';
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int col = colIndex; col < n; col += 2)
                        {
                            if (forest[rowIndex, col] == 'S' || forest[rowIndex, col] == 'B' || forest[rowIndex, col] == 'W')
                            {
                                wildboarTruffleCount++;
                                forest[rowIndex, col] = '-';
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"Peter manages to harvest {blackTruffleCount} black, {summerTruffleCount} summer, and {whiteTruffleCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildboarTruffleCount} truffles.");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(forest[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
