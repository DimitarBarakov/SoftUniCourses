using System;

namespace _03._Хистограма
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countUnder200 = 0;
            int countUnder399 = 0;
            int countUnder599 = 0;
            int countUnder799 = 0;
            int countOver800 = 0;
            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num<200)
                {
                    countUnder200++;
                }
                else if (num>=200 && num<=399)
                {
                    countUnder399++;
                }
                else if (num >= 400 && num <= 599)
                {
                    countUnder599++;
                }
                else if (num >= 600 && num <= 799)
                {
                    countUnder799++;
                }
                else if (num>=800)
                {
                    countOver800++;
                }
            }
            Console.WriteLine($"{countUnder200*1.0/n*100:f2}%");
            Console.WriteLine($"{countUnder399*1.0 / n * 100:f2}%");
            Console.WriteLine($"{countUnder599*1.0 / n * 100:f2}%");
            Console.WriteLine($"{countUnder799*1.0 / n * 100:f2}%");
            Console.WriteLine($"{countOver800*1.0 / n * 100:f2}%");
        }
    }
}
