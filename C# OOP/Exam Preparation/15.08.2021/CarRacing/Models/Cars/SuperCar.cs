using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class SuperCar:Car
    {
        private const double fuel = 80;
        private const double fuelConsupmtion = 10;
        public SuperCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, fuel, fuelConsupmtion)
        {
        }
    }
}
