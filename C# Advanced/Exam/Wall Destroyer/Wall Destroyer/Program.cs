using System;

namespace Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] wall = new char[n, n];
            int vankoRow = 0;
            int vankoCol = 0;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                char[] els = input.ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    wall[row, col] = els[col];
                    if (wall[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }
            int createdHoles = 1;
            int rodHits = 0;

            string dir;
            while ((dir = Console.ReadLine()) != "End")
            {
                if (dir == "up")
                {
                    if (vankoRow > 0)
                    {
                        if (wall[vankoRow - 1, vankoCol] == '-')
                        {
                            wall[vankoRow, vankoCol] = '*';
                            vankoRow--;
                            createdHoles++;
                            wall[vankoRow, vankoCol] = 'V';
                        }
                        else if (wall[vankoRow - 1, vankoCol] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodHits++;
                        }
                        else if (wall[vankoRow - 1, vankoCol] == 'C')
                        {
                            wall[vankoRow, vankoCol] = '*';
                            vankoRow--;
                            wall[vankoRow, vankoCol] = 'E';
                            createdHoles++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {createdHoles} hole(s).");
                            for (int row = 0; row < n; row++)
                            {
                                string line = "";
                                for (int col = 0; col < n; col++)
                                {
                                    line += wall[row, col];
                                }
                                Console.WriteLine(line);
                            }
                            return;
                        }
                        else if (wall[vankoRow - 1, vankoCol] == '*')
                        {
                            vankoRow--;
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                        }
                    }
                }
                if (dir == "down")
                {
                    if (vankoRow < n - 1)
                    {
                        if (wall[vankoRow + 1, vankoCol] == '-')
                        {
                            wall[vankoRow, vankoCol] = '*';
                            vankoRow++;
                            createdHoles++;
                            wall[vankoRow, vankoCol] = 'V';
                        }
                        else if (wall[vankoRow + 1, vankoCol] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodHits++;
                        }
                        else if (wall[vankoRow + 1, vankoCol] == 'C')
                        {
                            wall[vankoRow, vankoCol] = 'E';
                            createdHoles++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {createdHoles} hole(s).");
                            for (int row = 0; row < n; row++)
                            {
                                string line = "";
                                for (int col = 0; col < n; col++)
                                {
                                    line += wall[row, col];
                                }
                                Console.WriteLine(line);
                            }
                            return;
                        }
                        else if (wall[vankoRow + 1, vankoCol] == '*')
                        {
                            vankoRow++;
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                        }
                    }
                }
                if (dir == "left")
                {
                    if (vankoCol > 0)
                    {
                        if (wall[vankoRow, vankoCol - 1] == '-')
                        {
                            wall[vankoRow, vankoCol] = '*';
                            vankoCol--;
                            createdHoles++;
                            wall[vankoRow, vankoCol] = 'V';
                        }
                        else if (wall[vankoRow, vankoCol - 1] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodHits++;
                        }
                        else if (wall[vankoRow, vankoCol - 1] == 'C')
                        {
                            wall[vankoRow, vankoCol] = '*';
                            vankoCol--;
                            wall[vankoRow, vankoCol] = 'E';
                            createdHoles++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {createdHoles} hole(s).");
                            for (int row = 0; row < n; row++)
                            {
                                string line = "";
                                for (int col = 0; col < n; col++)
                                {
                                    line += wall[row, col];
                                }
                                Console.WriteLine(line);
                            }
                            return;
                        }
                        else if (wall[vankoRow, vankoCol - 1] == '*')
                        {
                            wall[vankoRow, vankoCol] = '*';
                            vankoCol--;
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                        }
                    }
                }
                if (dir == "right")
                {
                    if (vankoCol < n - 1)
                    {
                        if (wall[vankoRow, vankoCol + 1] == '-')
                        {
                            wall[vankoRow, vankoCol] = '*';
                            vankoCol++;
                            createdHoles++;
                            wall[vankoRow, vankoCol] = 'V';
                        }
                        else if (wall[vankoRow, vankoCol + 1] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodHits++;
                        }
                        else if (wall[vankoRow, vankoCol + 1] == 'C')
                        {
                            wall[vankoRow, vankoCol] = '*';
                            vankoCol++;
                            wall[vankoRow, vankoCol] = 'E';
                            createdHoles++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {createdHoles} hole(s).");
                            for (int row = 0; row < n; row++)
                            {
                                string line = "";
                                for (int col = 0; col < n; col++)
                                {
                                    line += wall[row, col];
                                }
                                Console.WriteLine(line);
                            }
                            return;
                        }
                        else if (wall[vankoRow, vankoCol + 1] == '*')
                        {
                            wall[vankoRow, vankoCol] = '*';
                            vankoCol++;
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                        }
                    }
                }
            }
            Console.WriteLine($"Vanko managed to make {createdHoles} hole(s) and he hit only {rodHits} rod(s).");
            for (int row = 0; row < n; row++)
            {
                string line = "";
                for (int col = 0; col < n; col++)
                {
                    line += wall[row, col];
                }
                Console.WriteLine(line);
            }
        }
    }
}
