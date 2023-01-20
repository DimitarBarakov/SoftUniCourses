using System;
using System.Numerics;

namespace _11._Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int snowballCount = int.Parse(Console.ReadLine());
            BigInteger bestValue = 0;
            int bestsnowballSnow = 0;
            int bestsnowballTime = 0;
            int bestsnowballQuality = 0;
            for (int i = 1; i <= snowballCount; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime),snowballQuality);
                if (snowballValue>bestValue)
                {
                    bestValue = snowballValue;
                    bestsnowballQuality = snowballQuality;
                    bestsnowballSnow = snowballSnow;
                    bestsnowballTime = snowballTime;
                      
                }
            }
            Console.WriteLine($"{bestsnowballSnow} : {bestsnowballTime} = {bestValue} ({bestsnowballQuality})");
        }
    }
}
