using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> carsCollection = new List<Car>();   
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumption = double.Parse(carInfo[2]);
                Car car = new Car(model, fuelAmount,fuelConsumption);
                //car.Model = model;
                //car.FuelAmount = fuelAmount;
                //car.FuelConsumptionPerKilometer = fuelConsumption;
                carsCollection.Add(car);
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] tokens = cmd.Split();
                string model = tokens[1];
                double kilometers = double.Parse(tokens[2]);
                Car carToDrive = carsCollection.First(car => car.Model == model);
                carToDrive.Drive(kilometers);
            }

            foreach (var car in carsCollection)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
