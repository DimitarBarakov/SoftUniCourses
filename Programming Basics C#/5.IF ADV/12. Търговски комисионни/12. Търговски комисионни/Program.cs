using System;

namespace _12._Търговски_комисионни
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double commision = 0;
            if (city == "Sofia")
            {
                if (sales>=0&&sales<=500)
                {
                    commision += 5.0 / 100 * sales;
                }
                else if (sales > 500 && sales <= 1000)
                {
                    commision += 7.0 / 100 * sales;
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    commision += 8.0 / 100 * sales;
                }
                else if (sales > 10000 )
                {
                    commision += 12.0 / 100 * sales;
                }
                else if (sales<0)
                {
                    Console.WriteLine("error"); return;
                }
            }
            else if (city == "Varna")
            {
                if (sales >= 0 && sales <= 500)
                {
                    commision += 4.5 / 100 * sales;
                }
                else if (sales > 500 && sales <= 1000)
                {
                    commision += 7.5 / 100 * sales;
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    commision += 10.0 / 100 * sales;
                }
                else if (sales > 10000)
                {
                    commision += 13.0 / 100 * sales;
                }
                else if (sales < 0)
                {
                    Console.WriteLine("error"); return;
                }
            }
            else if (city == "Plovdiv")
            {
                if (sales >= 0 && sales <= 500)
                {
                    commision += 5.5 / 100 * sales;
                }
                else if (sales > 500 && sales <= 1000)
                {
                    commision += 8.0 / 100 * sales;
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    commision += 12.0 / 100 * sales;
                }
                else if (sales > 10000)
                {
                    commision += 14.5 / 100 * sales;
                }
                else if (sales < 0)
                {
                    Console.WriteLine("error"); return;
                }
            }
            else
            {
                Console.WriteLine("error"); return;
            }
            Console.WriteLine($"{commision:f2}");
        }
    }
}
