using System;

namespace _11._Магазин_за_плодове
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double sum = 0;
            if (day=="Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                if (product=="banana")
                {
                    sum +=quantity * 2.50;
                }
                else if (product=="apple")
                {
                    sum += quantity * 1.20;
                }
                else if (product == "orange")
                {
                    sum += quantity * 0.85;
                }
                else if (product == "grapefruit")
                {
                    sum += quantity * 1.45;
                }
                else if (product == "kiwi")
                {
                    sum += quantity * 2.70;
                }
                else if (product == "pineapple")
                {
                    sum += quantity * 5.50;
                }
                else if (product == "grapes")
                {
                    sum += quantity * 3.85;
                }
                else
                {
                    Console.WriteLine("error"); return;
                }
            }
            else if(day=="Sunday" || day == "Saturday")
            {
                if (product == "banana")
                {
                    sum += quantity * 2.70;
                }
                else if (product == "apple")
                {
                    sum += quantity * 1.25;
                }
                else if (product == "orange")
                {
                    sum += quantity * 0.90;
                }
                else if (product == "grapefruit")
                {
                    sum += quantity * 1.60;
                }
                else if (product == "kiwi")
                {
                    sum += quantity * 3.00;
                }
                else if (product == "pineapple")
                {
                    sum += quantity * 5.60;
                }
                else if (product == "grapes")
                {
                    sum += quantity * 4.20;
                }
                else
                {
                    Console.WriteLine("error"); return;
                }
            }
            else
            {
                Console.WriteLine("error"); return;
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}
