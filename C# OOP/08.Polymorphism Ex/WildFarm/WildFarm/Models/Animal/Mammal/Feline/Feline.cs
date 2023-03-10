using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animal.Mammal.Feline
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingregion, string breed) : base(name, weight, livingregion)
        {
            this.Breed = breed;
        }

        public string Breed { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
