using System;

namespace _02._Конзолен_конвертор_от_радиани_в_градуси
{
    class Program
    {
        static void Main(string[] args)
        {
            double rad = double.Parse(Console.ReadLine());
            Console.WriteLine(rad * 180/Math.PI);
        }
    }
}
