using System;

namespace secondTry
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
            bool isElectrocuted = false;

            string dir;
            while ((dir = Console.ReadLine()) != "End")
            {
                
                if (dir == "up")
                {
                    if (vankoRow > 0)
                    {
                        wall[vankoRow, vankoCol] = '*';
                        vankoRow--;
                        if (wall[vankoRow, vankoCol] == '-')
                        {
                            createdHoles++;
                            wall[vankoRow, vankoCol] = 'V';
                        }
                        else if (wall[vankoRow, vankoCol] == 'R')
                        {
                            vankoRow++;
                            wall[vankoRow, vankoCol] = 'V';
                            Console.WriteLine("Vanko hit a rod!");
                            rodHits++;
                        }
                        else if (wall[vankoRow, vankoCol] == 'C')
                        {
                            isElectrocuted = true;
                            wall[vankoRow, vankoCol] = 'E';
                            createdHoles++;
                            break;
                        }
                        else if (wall[vankoRow, vankoCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                            wall[vankoRow, vankoCol] = 'V';
                        }
                    }
                }
                else if(dir == "down")
                {
                    
                    if (vankoRow < n - 1)
                    {
                        wall[vankoRow, vankoCol] = '*';
                        vankoRow++;
                        if (wall[vankoRow, vankoCol] == '-')
                        {
                            createdHoles++;
                            wall[vankoRow, vankoCol] = 'V';
                        }
                        else if (wall[vankoRow, vankoCol] == 'R')
                        {
                            vankoRow--;
                            wall[vankoRow, vankoCol] = 'V';
                            Console.WriteLine("Vanko hit a rod!");
                            rodHits++;
                        }
                        else if (wall[vankoRow, vankoCol] == 'C')
                        {
                            isElectrocuted = true;
                            wall[vankoRow, vankoCol] = 'E';
                            createdHoles++;
                            break;
                        }
                        else if (wall[vankoRow, vankoCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                            wall[vankoRow, vankoCol] = 'V';
                        }
                    }
                }
                else if (dir == "left")
                {
                    if (vankoCol > 0)
                    {
                        wall[vankoRow, vankoCol] = '*';
                        vankoCol--;
                        if (wall[vankoRow, vankoCol] == '-')
                        {
                            createdHoles++;
                            wall[vankoRow, vankoCol] = 'V';
                        }
                        else if (wall[vankoRow, vankoCol] == 'R')
                        {
                            vankoCol++;
                            wall[vankoRow, vankoCol] = 'V';
                            Console.WriteLine("Vanko hit a rod!");
                            rodHits++;
                        }
                        else if (wall[vankoRow, vankoCol] == 'C')
                        {
                            isElectrocuted = true;
                            wall[vankoRow, vankoCol] = 'E';
                            createdHoles++;
                            break;
                        }
                        else if (wall[vankoRow, vankoCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                            wall[vankoRow, vankoCol] = 'V';
                        }
                    }
                }
                else if (dir == "right")
                {   
                    if (vankoCol < n - 1)
                    {
                        wall[vankoRow, vankoCol] = '*';
                        vankoCol++;
                        if (wall[vankoRow, vankoCol] == '-')
                        {
                            createdHoles++;
                            wall[vankoRow, vankoCol] = 'V';
                        }
                        else if (wall[vankoRow, vankoCol] == 'R')
                        {
                            vankoCol--;
                            wall[vankoRow, vankoCol] = 'V';
                            Console.WriteLine("Vanko hit a rod!");
                            rodHits++;
                        }
                        else if (wall[vankoRow, vankoCol] == 'C')
                        {
                            isElectrocuted = true;
                            wall[vankoRow, vankoCol] = 'E';
                            createdHoles++;
                            break;
                        }
                        else if (wall[vankoRow, vankoCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                            wall[vankoRow, vankoCol] = 'V';
                        }
                    }
                }
            }
            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {createdHoles} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {createdHoles} hole(s) and he hit only {rodHits} rod(s).");
            }
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
