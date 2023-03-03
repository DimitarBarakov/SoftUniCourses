using System;

namespace The_Battle_of_the_Five_Armies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[,] map = new char[n, n];

            int armyRowIndex = 0;
            int armyColumnIndex = 0;
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                char[] el = input.ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    map[row, col] = el[col];
                    if (map[row, col] == 'A')
                    {
                        armyRowIndex = row;
                        armyColumnIndex = col;
                    }
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                string direction = tokens[0];
                int enemyRow = int.Parse(tokens[1]);
                int enemyCol = int.Parse(tokens[2]);

                map[enemyRow, enemyCol] = 'O';
                switch (direction)
                {
                    case "up": map[armyRowIndex, armyColumnIndex] = '-'; armyRowIndex--;  break;
                    case "down": map[armyRowIndex, armyColumnIndex] = '-'; armyRowIndex++;  break;
                    case "left": map[armyRowIndex, armyColumnIndex] = '-'; armyColumnIndex--;  break;
                    case "right": map[armyRowIndex, armyColumnIndex] = '-'; armyColumnIndex++;  break;
                    default:
                        break;
                }
                armor--;
                if ((armyRowIndex >=0 && armyRowIndex<n)&&(armyColumnIndex >= 0 && armyColumnIndex < n))
                {
                    if (map[armyRowIndex, armyColumnIndex] == 'O')
                    {
                        armor -= 2;
                        if (armor <= 0)
                        {
                            map[armyRowIndex, armyColumnIndex] = 'X';
                            Console.WriteLine($"The army was defeated at {armyRowIndex};{armyColumnIndex}.");
                            break;
                        }
                    }
                    else if (map[armyRowIndex, armyColumnIndex] == 'M')
                    {
                        map[armyRowIndex, armyColumnIndex] = '-';
                        Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                        break;
                    }
                }
            }

            for(int row = 0; row < n; row++)
            {
                string line = "";
                for (int col = 0; col < n; col++)
                {
                    line += map[row, col];
                }
                Console.WriteLine(line);
            }
        }
    }
}