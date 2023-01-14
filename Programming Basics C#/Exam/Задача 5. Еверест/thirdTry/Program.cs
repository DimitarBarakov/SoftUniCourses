using System;

namespace thirdTry
{
    class Program
    {
        static void Main(string[] args)
        {

            int climbedMeters = 5364;
            int days = 1;
            string comm = Console.ReadLine();
            while (days < 5&&climbedMeters<8848)
            {
                if (comm=="END")
                {
                    break;
                }
                if (comm == "Yes")
                {
                    days++;
                }
                
                int meters = int.Parse(Console.ReadLine());
                climbedMeters += meters;
                
                comm = Console.ReadLine();
            }
            if (climbedMeters >= 8848&& days == 5)
            {
                Console.WriteLine($"Goal reached for {days} days!");
                return;
            }
            if (days==5 && climbedMeters < 8848)
            {
                Console.WriteLine("Failed!");
                Console.WriteLine(climbedMeters);
                return;
            }
            if (days != 5 && climbedMeters < 8848)
            {
                Console.WriteLine("Failed!");
                Console.WriteLine(climbedMeters);
                return;
            }
            if (days != 5 && climbedMeters >= 8848)
            {
                Console.WriteLine($"Goal reached for {days} days!");
                return;
            }
            Console.WriteLine("Failed!");
            Console.WriteLine(climbedMeters);
        }
    }
}
