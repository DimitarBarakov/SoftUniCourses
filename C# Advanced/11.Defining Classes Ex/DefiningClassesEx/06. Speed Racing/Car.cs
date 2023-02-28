using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }


        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }


        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.fuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }


        public void Drive(double distance)
        {
            if (this.fuelAmount >= distance*this.fuelConsumptionPerKilometer)
            {
                this.fuelAmount -= distance * this.fuelConsumptionPerKilometer;
                this.travelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

    }
}
