using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _06._Vehicle_Catalogue
{
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            List<Vehicle> vehicles = new List<Vehicle>();
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();
                Vehicle newVehicle = new Vehicle();
                newVehicle.Type = tokens[0];
                newVehicle.Model = tokens[1];
                newVehicle.Color = tokens[2];
                newVehicle.HorsePower = double.Parse(tokens[3]);

                vehicles.Add(newVehicle);
            }

            string info;
            while ((info = Console.ReadLine()) != "Close the Catalogue")
            {

                Vehicle searchedVehicle = vehicles.FirstOrDefault(v => v.Model == info || v.Color == info);
                Console.WriteLine($"Type: {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(searchedVehicle.Type.ToLower())}"); 
                Console.WriteLine($"Model: {searchedVehicle.Model}");
                Console.WriteLine($"Color: {searchedVehicle.Color}");
                Console.WriteLine($"Horsepower: {searchedVehicle.HorsePower}");
            }

            double carsAverageHorsePower = 0;
            int carsCount = 0;
            double trucksAverageHorsePower = 0;
            int trucksCount = 0;
            for (int i = 0; i < vehicles.Count; i++)
            {
                Vehicle currVehicle = vehicles[i];
                if (currVehicle.Type == "car")
                {
                    carsCount++;
                    carsAverageHorsePower+=currVehicle.HorsePower;
                }
                else
                {
                    trucksCount++;
                    trucksAverageHorsePower+= currVehicle.HorsePower;
                }
            }
            Console.WriteLine($"Cars have average horsepower of: {carsAverageHorsePower/carsCount*1.0:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAverageHorsePower/trucksCount*1.0:f2}.");
        }
    }
}
