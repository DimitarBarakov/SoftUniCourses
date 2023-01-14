using System;

namespace secTry
{
    class Program
    {
        static void Main(string[] args)
        {
            int climbedMeters = 5364;
            int days = 1;
            string comm = Console.ReadLine();
            while (comm != "END")
            {
                int meters = int.Parse(Console.ReadLine());
                if (comm == "Yes")
                {
                    days++;
                    if (days == 5)
                    {
                        Console.WriteLine("Failed!");
                        Console.WriteLine($"{climbedMeters}");
                        break;
                    }
                    climbedMeters += meters;
                }
                else
                {
                    climbedMeters += meters;
                }
                if (climbedMeters >= 8848)
                {
                    Console.WriteLine($"Goal reached for {days} days!");
                    break;
                }
                comm = Console.ReadLine();
            }
            if (comm=="END")
            {
                if (climbedMeters >= 8848)
                {
                    Console.WriteLine($"Goal reached for {days} days!");
                }
                else
                {
                    Console.WriteLine("Failed!");
                    Console.WriteLine($"{climbedMeters}");
                }
            }
            
        }
    }
}
