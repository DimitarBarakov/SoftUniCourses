using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animal.Mammal
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name,double weight, string livingregion) : base(name, weight)
        {
            this.LivingRegion = livingregion;
        }

        public string LivingRegion { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
