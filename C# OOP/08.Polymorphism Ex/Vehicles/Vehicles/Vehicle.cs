using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double fq, double fc, double tankc)
        {
            this.FuelConsumption = fc;
            this.TankCapacity = tankc;
            this.FuelQuantity = fq;
        }
        public double TankCapacity
        {
            get { return tankCapacity; }
            set
            {
                tankCapacity = value;
            }
        }


        public virtual double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }


        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }
                fuelQuantity = value;
            }
        }

        public string Drive(double distance)
        {
            if (this.FuelConsumption * distance > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            else
            {
                this.FuelQuantity -= this.FuelConsumption * distance;
                return $"{this.GetType().Name} travelled {distance} km";
            }
        }

        public virtual void Fuel(double amount)
        {
            double avaibleSpace = this.TankCapacity - this.FuelQuantity;
            if (amount<=0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (avaibleSpace < amount)
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += amount;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
