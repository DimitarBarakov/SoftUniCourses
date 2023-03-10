using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animal.Birds
{
    public class Hen : Bird
    {
        private const double WeightIncrement = 0.35;
        public Hen(string name, double weight, double wingsize) : base(name, weight, wingsize)
        {
        }

        public override void Feed(string food, int quantity)
        {
            this.FoodEaten += quantity;
            this.Weight += quantity * WeightIncrement;
        }

        public override string Sound()
        {
            return "Cluck";
        }
    }
}
