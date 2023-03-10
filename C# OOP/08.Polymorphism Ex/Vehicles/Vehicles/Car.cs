using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double fuelIncresement = 0.9;
        public Car(double fuelquantity, double fuelconsumption, double tankCapacity):base(fuelquantity, fuelconsumption, tankCapacity)
        {
        }

        public override double FuelConsumption 
        { 
            get => base.FuelConsumption;
            set => base.FuelConsumption = value + fuelIncresement;
        }

        
    }
}
