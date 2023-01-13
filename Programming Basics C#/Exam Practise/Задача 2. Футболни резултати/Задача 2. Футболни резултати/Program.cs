using System;

namespace Задача_2._Футболни_резултати
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstMatch = Console.ReadLine();
            string secMatch = Console.ReadLine();
            string thirdtMatch = Console.ReadLine();
            int won = 0;
            int lost = 0;
            int drawn = 0;
            if (firstMatch[0] > firstMatch[2])
            {
                won++;
            }
            if (firstMatch[0] == firstMatch[2])
            {
                drawn++;
            }
            if (firstMatch[0] < firstMatch[2])
            {
                lost++;
            }
            if (secMatch[0] > secMatch[2])
            {
                won++;
            }
            if (secMatch[0] == secMatch[2])
            {
                drawn++;
            }
            if (secMatch[0] < secMatch[2])
            {
                lost++;
            }
            if (thirdtMatch[0]>thirdtMatch[2])
            {
                won++;
            }
            if (thirdtMatch[0] == thirdtMatch[2])
            {
                drawn++;
            }
            if (thirdtMatch[0] < thirdtMatch[2])
            {
                lost++;
            }
            Console.WriteLine($"Team won {won} games.");
            Console.WriteLine($"Team lost {lost} games.");
            Console.WriteLine($"Drawn games: {drawn}");
        }
    }
}
