using System;

namespace _09._Аквариум
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght  = int.Parse(Console.ReadLine());
            int widht = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            double volumeInCM = lenght * widht * height;
            double volumeInL = volumeInCM / 1000;
            double neededLitrea = volumeInL * (1 - percent/100);
            Console.WriteLine(neededLitrea);
        }
    }
}
