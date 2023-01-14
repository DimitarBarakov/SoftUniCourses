using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int climbedMeters = 5364;
            for (int i = 2; i < 5; i++)
            {
                string comm = Console.ReadLine();
                if (comm=="END")
                {
                    break;
                }
                int meters = int.Parse(Console.ReadLine());
                climbedMeters += meters;
                if (climbedMeters>=8848)
                {
                    Console.WriteLine($"Goal reached for {i} days!");
                    return;
                }
            }
            Console.WriteLine("Failed!");
            Console.WriteLine(climbedMeters);
            return;
        }
    }
}
