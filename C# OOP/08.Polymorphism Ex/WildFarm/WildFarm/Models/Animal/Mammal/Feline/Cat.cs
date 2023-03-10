using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animal.Mammal.Feline
{
    public class Cat : Feline
    {
        private const double WeightIncrement = 0.30;
        public Cat(string name, double weight, string livingregion, string breed) : base(name, weight, livingregion, breed)
        {
        }

        public override void Feed(string food, int quantity)
        {
            if (food == "Vegetable" || food == "Meat")
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
            return "Meow";
        }
    }
}
