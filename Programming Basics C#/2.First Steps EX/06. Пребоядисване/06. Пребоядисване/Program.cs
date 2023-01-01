using System;

namespace _06._Пребоядисване
{
    class Program
    {
        static void Main(string[] args)
        {
            int nailon = int.Parse(Console.ReadLine());
            int boq = int.Parse(Console.ReadLine());
            int razreditel = int.Parse(Console.ReadLine());
            int chasove = int.Parse(Console.ReadLine());
            double dopBoq = boq + boq * 0.1;
            double sumaNailon = (nailon + 2) * 1.5;
            double sumaBoq = dopBoq * 14.5;
            double razreditelSuma = razreditel * 5;

            double sumaZaMatreriali = sumaBoq + sumaNailon + razreditelSuma + 0.4;
            double sumaZaMaistori = sumaZaMatreriali * 0.3 * chasove;
            double krainaSUma = sumaZaMatreriali + sumaZaMaistori;
            Console.WriteLine(krainaSUma);
        }
    }
}
