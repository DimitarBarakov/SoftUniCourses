using System;

namespace Problem_1___Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCOunt = int.Parse(Console.ReadLine());
            int totalNumberOfLectures = int.Parse(Console.ReadLine());
            int additionalBous = int.Parse(Console.ReadLine());
            int maxAttendences = 0;
            double maxBonuses = 0;
            for (int i = 1; i <= studentsCOunt; i++)
            {
                int attendances = int.Parse(Console.ReadLine());
                double totalBonus = attendances * 1.0 / totalNumberOfLectures * (5 + additionalBous);
                if (totalBonus > maxBonuses)
                {
                    maxBonuses = totalBonus;
                    maxAttendences = attendances;
                }
            }
            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonuses)}.");
            Console.WriteLine($"The student has attended {maxAttendences} lectures.");
        }
    }
}
