using System;
using System.Text;

namespace Problem_1___World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string tour = Console.ReadLine();
            //StringBuilder  = new StringBuilder(text);
            string command;
            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] tokens = command.Split(':');
                string action = tokens[0];
                if (action == "Add Stop")
                {
                    int index = int.Parse(tokens[1]);
                    if (index >=0 && index<tour.Length)
                    {
                        string dest = tokens[2];
                        tour = tour.Insert(index, dest);
                        
                    }
                    Console.WriteLine(tour);
                }
                else if (action == "Remove Stop")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    if (startIndex>=0 && startIndex<tour.Length && endIndex>=0 && endIndex<tour.Length)
                    {
                        int lenght = endIndex - startIndex + 1;
                        tour = tour.Remove(startIndex, lenght);
                       
                    }
                    Console.WriteLine(tour);
                }
                else if (action == "Switch")
                {
                    string oldString = tokens[1];
                    string newString = tokens[2];
                    if (tour.Contains(oldString))
                    {
                       tour = tour.Replace(oldString, newString);
                    }
                    Console.WriteLine(tour);
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {tour}");
        }
    }
}
