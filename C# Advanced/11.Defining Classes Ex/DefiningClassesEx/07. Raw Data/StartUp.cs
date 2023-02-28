

namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                List<Tire> tires = new List<Tire>();
                for (int j = 5; j <= 12; j += 2)
                {
                    int age = int.Parse(carInfo[j + 1]);
                    double prssure = double.Parse(carInfo[j]);
                    Tire tire = new Tire();
                    tire.Age = age;
                    tire.Pressure = prssure;
                    tires.Add(tire);
                }
                Engine engine = new Engine();
                engine.Speed = engineSpeed;
                engine.Power = enginePower;

                Cargo cargo = new Cargo();
                cargo.Weight = cargoWeight;
                cargo.Type = cargoType;
                Car car = new Car(model, engine, cargo, tires.ToArray());
                carsCollection.Add(car);
            }

            List<Car> filteredCars = new List<Car>();
            string type = Console.ReadLine();
            if (type == "fragile")
            {
                filteredCars = carsCollection.Where(car => car.Cargo.Type == type).Where(car => car.Tires.Any(tire => tire.Pressure < 1)).ToList();
            }
            else
            {
                filteredCars = carsCollection.Where(car => car.Cargo.Type == type).Where(car => car.Engine.Power > 250).ToList();
            }
            foreach (var car in filteredCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
