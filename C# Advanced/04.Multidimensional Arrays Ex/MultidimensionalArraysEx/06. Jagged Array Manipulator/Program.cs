using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rowsCount][];
            for (int i = 0; i < rowsCount; i++)
            {
                int[] el = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagged[i] = el;
            }

            for (int row = 1; row < rowsCount; row++)
            {
                if (jagged[row].Length == jagged[row-1].Length)
                {
                    jagged[row] = jagged[row].Select(x => x * 2).ToArray();
                    jagged[row - 1] = jagged[row - 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    jagged[row] = jagged[row].Select(x => x / 2).ToArray();
                    jagged[row - 1] = jagged[row - 1].Select(x => x / 2).ToArray();
                }
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] tokens = cmd.Split();
                string action = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if ((row >= 0 && row < rowsCount) && (col >= 0 && col < jagged[row].Length))
                {
                    if (action == "Add")
                    {
                        jagged[row][col] += value;
                    }
                    else
                    {
                        jagged[row][col] -= value;
                    }
                }
            }
            foreach (var row in jagged)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
    }
}
