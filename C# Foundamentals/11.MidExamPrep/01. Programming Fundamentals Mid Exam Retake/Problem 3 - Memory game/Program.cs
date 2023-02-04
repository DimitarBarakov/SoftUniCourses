using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Memory_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> elemnets = Console.ReadLine().Split().ToList();
            string command;
            int moves = 0;
            while ((command = Console.ReadLine()) != "end")
            {
                if (elemnets.Count == 0)
                {
                    continue;
                }
                moves++;
                string[] tokens = command.Split();
                int index1 = int.Parse(tokens[0]);
                int index2 = int.Parse(tokens[1]);
                
                if ((index1 == index2) || (index1 < 0) || (index1 >= elemnets.Count) || (index2 < 0) || (index2 >= elemnets.Count))
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    if (elemnets.Count % 2 == 0)
                    {
                        elemnets.Insert(elemnets.Count / 2, $"-{moves}a");
                        elemnets.Insert(elemnets.Count / 2, $"-{moves}a");
                    }
                    else
                    {
                        elemnets.Insert(elemnets.Count / 2 + 1, $"-{moves}a");
                        elemnets.Insert(elemnets.Count / 2 + 1, $"-{moves}a");
                    }
                }
                else
                {
                    if (elemnets[index1] == elemnets[index2])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {elemnets[index2]}!");
                        if (index1 > index2)
                        {
                            elemnets.RemoveAt(index1);
                            elemnets.RemoveAt(index2);
                        }
                        else
                        {
                            elemnets.RemoveAt(index1);
                            elemnets.RemoveAt(index2 - 1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                }
            }
            if (elemnets.Count == 0)
            {
                Console.WriteLine($"You have won in {moves} turns!");
            }
            else
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(String.Join(' ', elemnets));
            }

        }
    }
}
