using System;

namespace _06._Световен_рекорд_по_плуване
{
    class Program
    {
        static void Main(string[] args)
        {
            double secondsRecord = double.Parse(Console.ReadLine());
            double metersRecord = double.Parse(Console.ReadLine());
            double metersPerSecond = double.Parse(Console.ReadLine());
            double delay = Math.Round(metersRecord / 15) * 12.50;
            double time = metersRecord * metersPerSecond + delay;
            if (time >= secondsRecord)
            {
                Console.WriteLine($"No, he failed! He was {time - secondsRecord:f2} seconds slower.");

            }
            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {time:f2} seconds.");
            }
        }
    }
}
