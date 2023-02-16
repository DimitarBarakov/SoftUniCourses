using System;
using System.Collections.Generic;

namespace Problem_3___Need_for_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> cars = new Dictionary<string, List<int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carAtributes = Console.ReadLine().Split('|');
                string car = carAtributes[0];
                int mileage = int.Parse(carAtributes[1]);
                int fuel = int.Parse(carAtributes[2]);
                cars.Add(car, new List<int> { mileage, fuel });
            }
            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] tokens = command.Split(" : ");
                string action =  tokens[0];
                if (action == "Drive")
                {
                    string car = tokens[1];
                    int distance = int.Parse(tokens[2]);
                    int fuel = int.Parse(tokens[3]);
                    if (cars[car][1] < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[car][1] -= fuel;
                        cars[car][0] += distance;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        if (cars[car][0] >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {car}!");
                            cars.Remove(car);
                        }
                    }
                }
                else if (action == "Refuel")
                {
                    string car = tokens[1];
                    int fuel = int.Parse(tokens[2]);
                    
                    if (cars[car][1] + fuel > 75)
                    {
                        fuel = 75 - cars[car][1];
                        cars[car][1] = 75;
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                    }
                    else
                    {
                        cars[car][1] += fuel;
                        Console.WriteLine(($"{car} refueled with {fuel} liters"));
                    }
                }
                else if (action == "Revert")
                {
                    string car = tokens[1];
                    int kilometers = int.Parse(tokens[2]);
                    if (cars[car][0] - kilometers < 10000)
                    {
                        cars[car][0] = 10000;
                    }
                    else
                    {
                        cars[car][0] -= kilometers;
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                }
            }
            foreach (var item in cars)
            {
                string car = item.Key;
                int mileage = item.Value[0];
                int fuel = item.Value[1];
                Console.WriteLine($"{car} -> Mileage: {mileage} kms, Fuel in the tank: {fuel} lt.");
            }
        }
    }
}
