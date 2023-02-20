using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rowsCount][];
            for (int i = 0; i < rowsCount; i++)
            {
                jagged[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string cmd;
            while ((cmd = Console.ReadLine())!="END")
            {
                string[] tokens = cmd.Split();
                string action = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (row >= 0 && row < rowsCount && col>=0&&col<jagged[row].Length)
                {
                    if (action == "Add")
                    {   
                        jagged[row][col] += value;
                    }
                    if (action == "Subtract")
                    {
                        jagged[row][col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }
            for (int row = 0; row < rowsCount; row++)
            {
                Console.WriteLine(String.Join(" ",jagged[row]));
            }
        }
    }
}
