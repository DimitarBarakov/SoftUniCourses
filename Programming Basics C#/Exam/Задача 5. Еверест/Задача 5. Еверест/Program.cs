using System;

namespace Задача_5._Еверест
{
    class Program
    {
        static void Main(string[] args)
        {
            string comm = Console.ReadLine();
            int climbedMeters = 5364;
            int days = 1;
            bool climbed = false;
            while (comm != "END")
            {
                if (comm == "Yes")
                {
                    days++;
                }
                int meters = int.Parse(Console.ReadLine());
                climbedMeters += meters;
                if (climbedMeters >= 8848)
                {
                    climbed = true;
                    break;
                }
                if (days == 5)
                {
                    
                    break;

                }
                comm = Console.ReadLine();
            }
            if (climbed)
            {
                Console.WriteLine($"Goal reached for {days} days!");
            }
            else
            {
                Console.WriteLine("Failed!");
                Console.WriteLine(climbedMeters);
            }
            
        }
    }
}
