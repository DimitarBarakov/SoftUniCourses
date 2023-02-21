using System;
using System.Linq;

namespace _09._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();

            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                char[] el = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = el[col];
                }
            }

            int positionRow = 0;
            int positionCol = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        positionCol = col;
                        positionRow = row;
                    }
                }
            }

            int coalCounter = 0;
            for (int i = 0; i < commands.Length; i++)
            {
                string currCommand = commands[i];
                if (currCommand == "up")
                {
                    if (positionRow - 1 >= 0)
                    {
                        positionRow -= 1;
                        if (matrix[positionRow, positionCol] == 'c')
                        {
                            coalCounter++;
                            matrix[positionRow, positionCol] = '*';
                            bool isThereMoreCoal = false;
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'c')
                                    {
                                        isThereMoreCoal = true;
                                        break;
                                    }
                                }
                                if (isThereMoreCoal)
                                {
                                    break;
                                }
                            }
                            if (!isThereMoreCoal)
                            {
                                Console.WriteLine($"You collected all coals! ({positionRow}, {positionCol})");
                                return;
                            }
                        }
                        else if (matrix[positionRow, positionCol] == 'e')
                        {
                            Console.WriteLine($"Game over!({ positionRow}, { positionCol})");
                            return;
                        }
                    }
                }
                else if (currCommand == "down")
                {
                    if (positionRow + 1 < n)
                    {
                        positionRow += 1;
                        if (matrix[positionRow, positionCol] == 'c')
                        {
                            coalCounter++;
                            matrix[positionRow, positionCol] = '*';
                            bool isThereMoreCoal = false;
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'c')
                                    {
                                        isThereMoreCoal = true;
                                        break;
                                    }
                                }
                                if (isThereMoreCoal)
                                {
                                    break;
                                }
                            }
                            if (!isThereMoreCoal)
                            {
                                Console.WriteLine($"You collected all coals! ({positionRow}, {positionCol})");
                                return;
                            }
                        }
                        else if (matrix[positionRow, positionCol] == 'e')
                        {
                            Console.WriteLine($"Game over!({ positionRow}, { positionCol})");
                            return;
                        }
                    }
                }
                else if (currCommand == "left")
                {
                    if (positionCol - 1 >= 0)
                    {
                        positionCol -= 1;
                        if (matrix[positionRow, positionCol] == 'c')
                        {
                            coalCounter++;
                            matrix[positionRow, positionCol] = '*';
                            bool isThereMoreCoal = false;
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'c')
                                    {
                                        isThereMoreCoal = true;
                                        break;
                                    }
                                }
                                if (isThereMoreCoal)
                                {
                                    break;
                                }
                            }
                            if (!isThereMoreCoal)
                            {
                                Console.WriteLine($"You collected all coals! ({positionRow}, {positionCol})");
                                return;
                            }
                        }
                        else if (matrix[positionRow, positionCol] == 'e')
                        {
                            Console.WriteLine($"Game over!({ positionRow}, { positionCol})");
                            return;
                        }
                    }
                }
                else if (currCommand == "right")
                {
                    {
                        if (positionCol + 1 < n)
                        {
                            positionCol += 1;
                            if (matrix[positionRow, positionCol] == 'c')
                            {
                                coalCounter++;
                                matrix[positionRow, positionCol] = '*';
                                bool isThereMoreCoal = false;
                                for (int row = 0; row < n; row++)
                                {
                                    for (int col = 0; col < n; col++)
                                    {
                                        if (matrix[row, col] == 'c')
                                        {
                                            isThereMoreCoal = true;
                                            break;
                                        }
                                    }
                                    if (isThereMoreCoal)
                                    {
                                        break;
                                    }
                                }
                                if (!isThereMoreCoal)
                                {
                                    Console.WriteLine($"You collected all coals! ({positionRow}, {positionCol})");
                                    return;
                                }
                            }
                            if (matrix[positionRow, positionCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({ positionRow}, { positionCol})");
                                return;
                            }
                        }
                    }
                }
            }

            int coalLeft = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        coalLeft++;
                    }
                }
            }
            Console.WriteLine($"{coalLeft} coals left. ({positionRow}, {positionCol})");
        }
    }
}
