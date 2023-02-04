using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2___Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine().Split('!').ToList();
            string command;
            while ((command = Console.ReadLine()) != "Go Shopping!")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                if (action=="Urgent")
                {
                    string item = tokens[1];
                    if (!groceries.Contains(item))
                    {
                        groceries.Insert(0,item);
                    }
                }
                else if (action == "Unnecessary")
                {
                    string item = tokens[1];
                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                    }
                }
                else if (action == "Correct")
                {
                    string oldItem = tokens[1];
                    string newItem = tokens[2];
                    if (groceries.Contains(oldItem))
                    {
                        groceries[groceries.IndexOf(oldItem)] = newItem;
                    }
                }
                else if (action == "Rearrange")
                {
                    string item = tokens[1];
                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                        groceries.Add(item);
                    }
                }
            }
            Console.WriteLine(String.Join(", ", groceries));
        }
    }
}
