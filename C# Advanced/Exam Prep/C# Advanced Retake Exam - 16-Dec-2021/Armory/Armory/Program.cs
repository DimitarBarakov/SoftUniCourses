using System;
using System.Linq;

namespace Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] armor = new char[n, n];

            int officerRowIndex = 0;
            int officerColIndex = 0;
            for (int row = 0; row < n; row++)
            {
                string ad = Console.ReadLine();
                char[] els = ad.ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    armor[row, col] = els[col];
                    if (armor[row, col] == 'A')
                    {
                        officerColIndex = col;
                        officerRowIndex = row;
                    }
                }
            }

            int moneyForSwords = 0;

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "up")
                {
                    if (officerRowIndex == 0)
                    {
                        armor[officerRowIndex, officerColIndex] = '-';
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }
                    else
                    {
                        armor[officerRowIndex, officerColIndex] = '-';
                        officerRowIndex--;
                        if (char.IsDigit(armor[officerRowIndex, officerColIndex]))
                        {
                            moneyForSwords += int.Parse(armor[officerRowIndex, officerColIndex].ToString());
                            if (moneyForSwords >= 65)
                            {
                                armor[officerRowIndex, officerColIndex] = 'A';
                                Console.WriteLine("Very nice swords, I will come back for more!");
                                break;
                            }
                            armor[officerRowIndex, officerColIndex] = 'A';
                        }
                        else if (armor[officerRowIndex, officerColIndex] == 'M')
                        {
                            armor[officerRowIndex, officerColIndex] = '-';
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (armor[row, col] == 'M')
                                    {
                                        armor[row, col] = 'A';
                                        officerRowIndex = row;
                                        officerColIndex = col;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (cmd == "down")
                {
                    if (officerRowIndex == n - 1)
                    {
                        armor[officerRowIndex, officerColIndex] = '-';
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }
                    else
                    {
                        armor[officerRowIndex, officerColIndex] = '-';
                        officerRowIndex++;
                        if (char.IsDigit(armor[officerRowIndex, officerColIndex]))
                        {
                            moneyForSwords += int.Parse(armor[officerRowIndex, officerColIndex].ToString());
                            if (moneyForSwords >= 65)
                            {
                                armor[officerRowIndex, officerColIndex] = 'A';
                                Console.WriteLine("Very nice swords, I will come back for more!");
                                break;
                            }
                            armor[officerRowIndex, officerColIndex] = 'A';
                        }
                        else if (armor[officerRowIndex, officerColIndex] == 'M')
                        {
                            armor[officerRowIndex, officerColIndex] = '-';
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (armor[row, col] == 'M')
                                    {
                                        armor[row, col] = 'A';
                                        officerRowIndex = row;
                                        officerColIndex = col;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (cmd == "left")
                {
                    armor[officerRowIndex, officerColIndex] = '-';
                    if (officerColIndex == 0)
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }
                    else
                    {
                        armor[officerRowIndex, officerColIndex] = '-';
                        officerColIndex--;
                        if (char.IsDigit(armor[officerRowIndex, officerColIndex]))
                        {
                            moneyForSwords += int.Parse(armor[officerRowIndex, officerColIndex].ToString());
                            if (moneyForSwords >= 65)
                            {
                                armor[officerRowIndex, officerColIndex] = 'A';
                                Console.WriteLine("Very nice swords, I will come back for more!");
                                break;
                            }
                            armor[officerRowIndex, officerColIndex] = 'A';
                        }
                        else if (armor[officerRowIndex, officerColIndex] == 'M')
                        {
                            armor[officerRowIndex, officerColIndex] = '-';
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (armor[row, col] == 'M')
                                    {
                                        armor[row, col] = 'A';
                                        officerRowIndex = row;
                                        officerColIndex = col;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (cmd == "right")
                {
                    armor[officerRowIndex, officerColIndex] = '-';
                    if (officerColIndex == n - 1)
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }
                    else
                    {
                        armor[officerRowIndex, officerColIndex] = '-';
                        officerColIndex++;
                        if (char.IsDigit(armor[officerRowIndex, officerColIndex]))
                        {
                            moneyForSwords += int.Parse(armor[officerRowIndex, officerColIndex].ToString());
                            if (moneyForSwords >= 65)
                            {
                                armor[officerRowIndex, officerColIndex] = 'A';
                                Console.WriteLine("Very nice swords, I will come back for more!");
                                break;
                            }
                            armor[officerRowIndex, officerColIndex] = 'A';
                        }
                        else if (armor[officerRowIndex, officerColIndex] == 'M')
                        {
                            armor[officerRowIndex, officerColIndex] = '-';
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (armor[row, col] == 'M')
                                    {
                                        armor[row, col] = 'A';
                                        officerRowIndex = row;
                                        officerColIndex = col;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"The king paid {moneyForSwords} gold coins.");
            for (int row = 0; row < n; row++)
            {
                string line = "";
                for (int col = 0; col < n; col++)
                {
                    line += armor[row, col];   
                }
                Console.WriteLine(line);
            }
        }
    }
}
