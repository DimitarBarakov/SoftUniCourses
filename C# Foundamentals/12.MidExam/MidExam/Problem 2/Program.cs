using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> coffees = Console.ReadLine().Split().ToList();
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= commandsCount; i++)
            {
                string command = Console.ReadLine();
                string[] tokens = command.Split(' ');
                string action = tokens[0];
                if (action == "Include")
                {
                    string coffee = tokens[1];
                    coffees.Add(coffee);
                }
                else if (action == "Remove")
                {
                    string pos = tokens[1];
                    int count = int.Parse(tokens[2]);
                    if (count < coffees.Count)
                    {
                        if (pos == "first")
                        {
                            RemoveFirst(coffees, count);
                        }
                        else if (pos == "last")
                        {
                            RemoveLast(coffees, count);
                        }
                    }
                }
                else if (action == "Prefer")
                {
                    int index1 = int.Parse(tokens[1]);
                    int index2 = int.Parse(tokens[2]);
                    if ((index1>=0) && (index1<coffees.Count) && (index2>=0) && (index2<coffees.Count))
                    {
                        string temp = coffees[index1];
                        coffees[index1] = coffees[index2];
                        coffees[index2] = temp;
                    }
                }
                else if (action == "Reverse")
                {
                    coffees.Reverse();
                }
            }
            Console.WriteLine("Coffees:");
            Console.WriteLine(string.Join(" ", coffees));
        }

        static List<string> RemoveFirst(List<string> prod, int count)
        {
            for (int i = 0; i < count; i++)
            {
                prod.RemoveAt(i);
                i--;
                count--;
            }
            return prod;
        }
        static List<string> RemoveLast(List<string> prod, int count)
        {
            for (int i = prod.Count - count; i < prod.Count; i++)
            {
                prod.RemoveAt(i);
                i--;
            }
            return prod;
        }
    }
}
