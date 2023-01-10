using System;

namespace _08._Завършване
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int gradesCount = 0;
            int badGrades = 0;
            double gradesSum = 0;
            while (gradesCount<12)
            {
                double grade = double.Parse(Console.ReadLine());
                gradesSum += grade;
                if (grade<4)
                {
                    badGrades++;
                    if (badGrades==2)
                    {
                        Console.WriteLine($"{name} has been excluded at {gradesCount} grade");
                        return;
                    }
                }
                gradesCount++;
            }
            Console.WriteLine($"{name} graduated. Average grade: {gradesSum/gradesCount:f2}");
        }
    }
}
