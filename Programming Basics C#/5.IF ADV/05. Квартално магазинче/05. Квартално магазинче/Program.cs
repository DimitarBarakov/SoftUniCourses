using System;

namespace _05._Квартално_магазинче
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double price = 0;
            if (product == "coffee")
            {
                if (city == "Sofia")
                {
                    price += 0.50 * quantity;
                }
                if (city == "Plovdiv")
                {
                    price += 0.40 * quantity;
                }
                if (city == "Varna")
                {
                    price += 0.45 * quantity;
                }
            }
            else if (product == "water")
            {
                if (city == "Sofia")
                {
                    price += 0.80 * quantity;
                }
                if (city == "Plovdiv")
                {
                    price += 0.70 * quantity;
                }
                if (city == "Varna")
                {
                    price += 0.70 * quantity;
                }
            }
            else if (product == "beer")
            {
                if (city == "Sofia")
                {
                    price += 1.20 * quantity;
                }
                if (city == "Plovdiv")
                {
                    price += 1.15 * quantity;
                }
                if (city == "Varna")
                {
                    price += 1.10 * quantity;
                }
            }
            else if (product == "sweets")
            {
                if (city == "Sofia")
                {
                    price += 1.45 * quantity;
                }
                if (city == "Plovdiv")
                {
                    price += 1.30 * quantity;
                }
                if (city == "Varna")
                {
                    price += 1.35 * quantity;
                }
            }
            else if (product == "peanuts")
            {
                if (city == "Sofia")
                {
                    price += 1.60 * quantity;
                }
                if (city == "Plovdiv")
                {
                    price += 1.50 * quantity;
                }
                if (city == "Varna")
                {
                    price += 1.55 * quantity;
                }
            }
            Console.WriteLine(price);
        }
    }

}

