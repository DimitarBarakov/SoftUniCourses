using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine().Split(", ").ToList();
            string command;
            while ((command = Console.ReadLine()) != "Craft!")
            {
                string[] tokens = command.Split(" - ");
                string action = tokens[0];
                if (action == "Collect")
                {
                    string item = tokens[1];
                    if (!inventory.Contains(item))
                    {
                        inventory.Add(item);
                    }
                }
                else if (action == "Drop")
                {
                    string item = tokens[1];
                    if (inventory.Contains(item))
                    {
                        inventory.Remove(item);
                    }
                }
                else if (action == "Combine Items")
                {
                    string[] splittedItems = tokens[1].Split(':');
                    string oldItem = splittedItems[0];
                    string newItem = splittedItems[1];
                    if (inventory.Contains(oldItem))
                    {
                        int indexToInsert = inventory.IndexOf(oldItem) + 1;
                        inventory.Insert(indexToInsert,newItem);
                    }
                }
                else if (action == "Renew")
                {
                    string item = tokens[1];
                    if (inventory.Contains(item))
                    {
                        inventory.Remove(item);
                        inventory.Add(item);
                    }
                    
                }
            }
            Console.WriteLine(string.Join(", ", inventory));
        }
    }
}
