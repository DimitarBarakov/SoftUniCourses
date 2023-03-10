using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double fuelIncresement = 1.6;
        public Truck(double fuelquantity, double fuelconsumption, double tankcapacity):base(fuelquantity, fuelconsumption, tankcapacity)
        {
        }

        public override double FuelConsumption
        { 
            get => base.FuelConsumption;
            set => base.FuelConsumption = value + fuelIncresement;
        }
        public override void Fuel(double amount)
        {
            double avaibleSpace = this.TankCapacity - this.FuelQuantity;
            if (amount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (avaibleSpace < amount)
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
            else
            {
                amount *= 0.95;
                this.FuelQuantity += amount;
            }
        }

        
    }
}
