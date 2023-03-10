using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animal.Mammal
{
    public class Mouse : Mammal
    {
        private const double WeightIncrement = 0.10;
        public Mouse(string name, double weight, string livingregion) : base(name, weight, livingregion)
        {
        }

        public override void Feed(string food, int quantity)
        {
            if (food == "Vegetable" || food == "Fruit")
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
            return "Squeak";
        }
    }
}
