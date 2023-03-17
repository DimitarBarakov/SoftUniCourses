using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double fuel = 65;
        private const double fuelConsupmtion = 7.5;
        public TunedCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, fuel, fuelConsupmtion)
        {
        }

        public override void Drive()
        {
            this.HorsePower = (int)Math.Round(this.HorsePower * 0.97);
            base.Drive();
        }
    }
}
