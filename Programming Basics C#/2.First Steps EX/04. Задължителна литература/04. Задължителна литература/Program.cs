using System;

namespace _04._Задължителна_литература
{
    class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            Console.WriteLine(pages/pagesPerHour/days);
        }
    }
}
