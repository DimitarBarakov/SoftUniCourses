using System;

namespace _08._Световна_ранглиста_по_тенис
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournamentsCount = int.Parse(Console.ReadLine());
            int startedPoints = int.Parse(Console.ReadLine());
            int wonPoints = 0;
            int wonTournaments = 0;
            for (int i = 1; i <= tournamentsCount; i++)
            {
                string reachedPhase = Console.ReadLine();
                if (reachedPhase=="W")
                {
                    wonPoints += 2000;
                    wonTournaments++;
                }
                else if (reachedPhase == "F")
                {
                    wonPoints += 1200;
                }
                else if (reachedPhase == "SF")
                {
                    wonPoints += 720;
                }
            }
            Console.WriteLine($"Final points: {startedPoints+wonPoints}");
            Console.WriteLine($"Average points: {Math.Floor(wonPoints * 1.0 / tournamentsCount)}");
            Console.WriteLine($"{wonTournaments*1.0/tournamentsCount*100:f2}%");
            
        }
    }
}
