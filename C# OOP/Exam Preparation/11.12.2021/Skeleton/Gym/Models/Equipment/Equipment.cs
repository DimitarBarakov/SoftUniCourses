using Gym.Models.Equipment.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        private double weight;
        private decimal price;
        public Equipment(double weight, decimal price)
        {
            this.Price = price;
            this.Weight = weight;
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public decimal Price
        {
            get { return price; }
            private set { price = value; }
        }
    }
}
