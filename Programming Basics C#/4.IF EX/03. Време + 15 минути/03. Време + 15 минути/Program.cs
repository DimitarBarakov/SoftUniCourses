using System;

namespace _03._Време___15_минути
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            minutes += 15;
            if (minutes < 60)
            {
                Console.WriteLine($"{hours}:{minutes}");
            }
            else if (minutes >= 60)
            {
                hours++;
                if (hours>=24)
                {
                    hours = 0;
                }
                minutes -= 60;
                if (minutes<10)
                {
                    Console.WriteLine($"{hours}:0{minutes}");
                }
                else
                {
                    Console.WriteLine($"{hours}:{minutes}");
                }
            }
        }
    }
}
