using System;

namespace _08._Обедна_почивка
{
    class Program
    {
        static void Main(string[] args)
        {
            string series = Console.ReadLine();
            int episodeTime = int.Parse(Console.ReadLine());
            int breakTime = int.Parse(Console.ReadLine());
            double launchTime = 1.0 / 8 * breakTime;
            double restTime = 1.0 / 4 * breakTime;
            double neededTime = episodeTime + launchTime + restTime;
            if (breakTime>=neededTime)
            {
                Console.WriteLine($"You have enough time to watch {series} and left with {Math.Ceiling(breakTime-neededTime)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {series}, you need {Math.Ceiling(neededTime-breakTime)} more minutes.");
            }
        }
    }
}
