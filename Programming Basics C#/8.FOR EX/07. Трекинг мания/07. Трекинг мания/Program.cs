using System;

namespace _07._Трекинг_мания
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupsCount = int.Parse(Console.ReadLine());
            int climbersForMusala = 0;
            int climbersForMonblan = 0;
            int climbersForKilim = 0;
            int climbersForK2 = 0;
            int climbersForEverest = 0;
            int allClimbers = 0;
            for (int i = 1; i <= groupsCount; i++)
            {
                int climbersPerGroup = int.Parse(Console.ReadLine());
                allClimbers += climbersPerGroup;
                if (climbersPerGroup <= 5)
                {
                    climbersForMusala += climbersPerGroup;
                }
                else if (climbersPerGroup >= 6 && climbersPerGroup <= 12)
                {
                    climbersForMonblan += climbersPerGroup;
                }
                else if (climbersPerGroup >= 13 && climbersPerGroup <= 25)
                {
                    climbersForKilim += climbersPerGroup;
                }
                else if (climbersPerGroup >= 26 && climbersPerGroup <= 40)
                {
                    climbersForK2 += climbersPerGroup;
                }
                else if (climbersPerGroup >= 41)
                {
                    climbersForEverest += climbersPerGroup;
                }
            }
            Console.WriteLine($"{climbersForMusala * 1.0 / allClimbers * 100:f2}%");
            Console.WriteLine($"{climbersForMonblan * 1.0 / allClimbers * 100:f2}%");
            Console.WriteLine($"{climbersForKilim * 1.0 / allClimbers * 100:f2}%");
            Console.WriteLine($"{climbersForK2 * 1.0 / allClimbers * 100:f2}%");
            Console.WriteLine($"{climbersForEverest * 1.0 / allClimbers * 100:f2}%");
        }
    }
}
