using System;

namespace _06._Оскари
{
    class Program
    {
        static void Main(string[] args)
        {
            string actor = Console.ReadLine();
            double startingPoints = double.Parse(Console.ReadLine());
            int judges = int.Parse(Console.ReadLine());
            double points = startingPoints;
            for (int i = 1; i <= judges; i++)
            {
                string judgeName = Console.ReadLine();
                double judgePoints = double.Parse(Console.ReadLine());
                points += judgeName.Length * judgePoints / 2;
                if (points>=1250.50)
                {
                    Console.WriteLine($"Congratulations, {actor} got a nominee for leading role with {points:f1}!");
                    return;
                }
            }
            Console.WriteLine($"Sorry, {actor} you need {1250.50 - points:f1} more!");
        }
    }
}
