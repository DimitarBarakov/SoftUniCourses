using System;

namespace Задача_1._Котешка_диета
{
    class Program
    {
        static void Main(string[] args)
        {
            int maznini = int.Parse(Console.ReadLine());
            int proteini = int.Parse(Console.ReadLine());
            int wuglehidrati = int.Parse(Console.ReadLine());
            int kalorii = int.Parse(Console.ReadLine());
            int voda = int.Parse(Console.ReadLine());

            double mazniniGrams = (maznini*1.0/100 * kalorii)*1.0 / 9;
            double proteiniGrams = (proteini*1.0/100 * kalorii)*1.0 / 4;
            double wuglehidratiGrams = (wuglehidrati*1.0/100 * kalorii)*1.0 / 4;

            double food = mazniniGrams + proteiniGrams + wuglehidratiGrams;
            double kaloriiZaGram = kalorii * 1.0 / food;
            double res = (100 - voda)*1.0 / 100 * kaloriiZaGram;
            Console.WriteLine($"{res:f4}");
        }
    }
}
