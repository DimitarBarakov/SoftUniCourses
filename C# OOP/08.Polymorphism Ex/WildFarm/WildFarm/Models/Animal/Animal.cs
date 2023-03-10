using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animal
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int FoodEaten { get; set; }
        public double Weight { get; set; }

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public abstract string Sound();

        public virtual void Feed(string food, int quantity)
        {
            
        }
    }
}
