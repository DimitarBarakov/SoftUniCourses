using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private int horsePower;
        private double defaultFuelConsumption ;
        private double fuelConsumption;
        private double fuel;


        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }


        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }


        public double DefaultFuelConsumption 
        {
            get { return defaultFuelConsumption ; }
            set { defaultFuelConsumption  = value; }
        }


        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        public Vehicle(int horsePower, double fuel)
        {
            DefaultFuelConsumption = 1.25;
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public virtual void Drive(double kilometres)
        {
            Fuel -= DefaultFuelConsumption * kilometres;
        }
    }
}
