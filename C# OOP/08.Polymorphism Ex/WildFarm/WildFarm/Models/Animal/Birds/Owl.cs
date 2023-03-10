using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animal.Birds
{
    public class Owl : Bird
    {
        private const double WeightIncrement = 0.25;
        public Owl(string name, double weight, double wingsize) : base(name, weight, wingsize)
        {
        }

        public override void Feed(string food, int quantity)
        {
            if (food == "Meat")
            {
                this.FoodEaten += quantity;
                this.Weight += quantity * WeightIncrement;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food}!");
            }
        }
        public override string Sound()
        {
            return "Hoot Hoot";
        }
    }
}
