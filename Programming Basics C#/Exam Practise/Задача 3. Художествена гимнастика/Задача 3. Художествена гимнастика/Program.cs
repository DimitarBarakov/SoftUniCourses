using System;

namespace Задача_3._Художествена_гимнастика
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string tool = Console.ReadLine();
            double grade = 0;
            if (country=="Russia")
            {
                if (tool=="ribbon")
                {
                    grade += 18.50;
                }
                else if (tool=="hoop")
                {
                    grade += 19.10;
                }
                else if (tool=="rope")
                {
                    grade += 18.60;
                }
            }
            else if (country == "Bulgaria")
            {
                if (tool == "ribbon")
                {
                    grade += 19.00;
                }
                else if (tool == "hoop")
                {
                    grade += 19.30;
                }
                else if (tool == "rope")
                {
                    grade += 18.90;
                }
            }
            else if (country == "Italy")
            {
                if (tool == "ribbon")
                {
                    grade += 18.70;
                }
                else if (tool == "hoop")
                {
                    grade += 18.80;
                }
                else if (tool == "rope")
                {
                    grade += 18.85;
                }
            }
            Console.WriteLine($"The team of {country} get {grade:f3} on {tool}.");
            Console.WriteLine($"{(20-grade)/20*100:f2}%");
        }
    }
}
