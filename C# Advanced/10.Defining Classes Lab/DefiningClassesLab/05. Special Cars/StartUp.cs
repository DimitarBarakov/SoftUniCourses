namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        public static void Main()
        {
            //Reading Tires
            List<List<Tire>> tirePacks = new List<List<Tire>>();
            string tirescmd;
            while ((tirescmd = Console.ReadLine()) != "No more tires")
            {
                string[] tokens = tirescmd.Split();
                tirePacks.Add(CreatePackOfTires(tokens));
            }

            //Reading Engines
            List<Engine> engines = new List<Engine>();
            string enginecmd;
            while ((enginecmd = Console.ReadLine()) != "Engines done")
            {
                string[] tokens = enginecmd.Split();
                engines.Add(CreateEngine(tokens));
            }


            //Reading Cars
            List<Car> cars = new List<Car>();
            string carcmd;
            while ((carcmd = Console.ReadLine()) != "Show special")
            {
                string[] tokens = carcmd.Split();
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                Engine engine = engines[engineIndex];
                int tiresIndex = int.Parse(tokens[6]);
                Tire[] tires = tirePacks[tiresIndex].ToArray();

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);
                cars.Add(car);
            }

            List<Car> specialCars = cars.Where(car => car.Year >= 2017).Where(car => car.Engine.HorsePower >= 330).Where(car => car.Tires.Sum(tire => tire.Pressure) > 9 && car.Tires.Sum(tire => tire.Pressure) < 10).ToList();
            foreach (Car car in specialCars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }

        public static List<Tire> CreatePackOfTires(string[] tokens)
        {
            List<Tire> tierPack = new List<Tire>();
            for (int i = 0; i < tokens.Length; i += 2)
            {
                int tireYear = int.Parse(tokens[i]);
                double tirePressure = double.Parse(tokens[i + 1]);
                Tire tire = new Tire(tireYear, tirePressure);
                tierPack.Add(tire);
            }
            return tierPack;
        }
        public static Engine CreateEngine(string[] tokens)
        {
            int horsePower = int.Parse(tokens[0]);
            double cubicCapacity = double.Parse(tokens[1]);
            Engine engine = new Engine(horsePower, cubicCapacity);
            return engine;
        }
    }
}
