using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                if (action == "Delete")
                {
                    int elemnetToDelete = int.Parse(tokens[1]);
                    numbers.RemoveAll(x => x == elemnetToDelete);
                }
                else if (action == "Insert")
                {
                    int elementToInsert = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    numbers.Insert(index, elementToInsert)
                }
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
