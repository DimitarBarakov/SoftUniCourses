using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Vehicle_Catalogue
{
    
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }

    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
    }
    class Catalog
    {
        public Catalog()
        {
            this.Cars = new List<Car>();
            this.Trucks = new List<Truck>();
        }
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split('/');
                string type = tokens[0];
                if (type == "Car")
                {
                    Car currCar = new Car();
                    currCar.Brand = tokens[1];
                    currCar.Model = tokens[2];
                    currCar.HorsePower = tokens[3];
                    catalog.Cars.Add(currCar);
                }
                else if (type == "Truck")
                {
                    Truck currTruck = new Truck();
                    currTruck.Brand = tokens[1];
                    currTruck.Model = tokens[2];
                    currTruck.Weight = tokens[3];
                    catalog.Trucks.Add(currTruck);
                }
            }
            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                List<Car> sortedCars = catalog.Cars.OrderBy(car => car.Brand).ToList();
                for (int i = 0; i < catalog.Cars.Count; i++)
                {
                    Console.WriteLine($"{sortedCars[i].Brand}: {sortedCars[i].Model} - {sortedCars[i].HorsePower}hp");
                }
            }
            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                List<Truck> sortedTrucks = catalog.Trucks.OrderBy(truck => truck.Brand).ToList();
                for (int i = 0; i < catalog.Trucks.Count; i++)
                {
                    Console.WriteLine($"{sortedTrucks[i].Brand}: {sortedTrucks[i].Model} - {sortedTrucks[i].Weight}kg");
                }
            }
        }
    }
}
