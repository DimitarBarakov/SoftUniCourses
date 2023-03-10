using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fq, double fc, double tankc) : base(fq, fc, tankc)
        {
        }

        public double Increasment { get; set; }
        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            set => base.FuelConsumption = value + this.Increasment;
        }
    }
}
