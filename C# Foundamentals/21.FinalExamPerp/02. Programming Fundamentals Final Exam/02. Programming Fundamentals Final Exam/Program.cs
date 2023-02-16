using System;

namespace _02._Programming_Fundamentals_Final_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string[] tokens = command.Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
