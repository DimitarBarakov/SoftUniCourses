using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();
                string cmdType = cmd[0];
                string vehicle = cmd[1];
                double parameter = double.Parse(cmd[2]);
                if (cmdType == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        Console.WriteLine(car.Drive(parameter));
                    }
                    else if (vehicle == "Truck")
                    {
                        Console.WriteLine(truck.Drive(parameter));
                    }
                    else if (vehicle == "Bus")
                    {
                        bus.FuelConsumption += 1.4;
                        Console.WriteLine(bus.Drive(parameter));
                        bus.FuelConsumption = double.Parse(busInfo[2]);
                    }
                }
                else if (cmdType == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.Fuel(parameter);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Fuel(parameter);
                    }
                    else if (vehicle == "Bus")
                    {
                        bus.Fuel(parameter);
                    }
                }
                else if (cmdType == "DriveEmpty")
                {
                    bus.FuelConsumption = double.Parse(busInfo[2]);
                    Console.WriteLine(bus.Drive(parameter));
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
