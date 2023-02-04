using System;

namespace Problem_1___Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double sum = 0;
            while (command  != "regular" && command != "special")
            {
                double price = double.Parse(command);
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    sum += price;
                }
                command = Console.ReadLine();
            }
            if (sum == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                double taxes = 0.2 * sum;
                double totalSum = sum + taxes;
                if (command == "special")
                {
                    totalSum *= 0.9;
                }
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {sum:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalSum:f2}$");
            }
        }
    }
}
