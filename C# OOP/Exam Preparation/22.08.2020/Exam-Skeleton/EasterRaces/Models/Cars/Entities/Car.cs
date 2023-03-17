using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsepower;
        private double cubicCentimeters;
        private int minHorsePower;
        private int maxHorsePower;
        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.CubicCentimeters = cubicCentimeters;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            this.HorsePower = horsePower;
        }
        public string Model
        {
            get { return model; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4));
                }
                model = value; 
            }
        }

        public int HorsePower
        {
            get { return horsepower; }
            private set 
            {
                if (value<minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                horsepower = value; 
            }
        }

        public double CubicCentimeters
        {
            get { return cubicCentimeters; }
            private set { cubicCentimeters = value; }
        }

        public double CalculateRacePoints(int laps)
        {
            double points = this.CubicCentimeters / this.HorsePower * laps;
            return points;
        }
    }
}
