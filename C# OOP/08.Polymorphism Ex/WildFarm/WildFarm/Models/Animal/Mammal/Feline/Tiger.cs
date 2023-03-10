using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animal.Mammal.Feline
{
    public class Tiger : Feline
    {
        private const double WeightIncrement = 1.00;
        public Tiger(string name, double weight, string livingregion, string breed) : base(name, weight, livingregion, breed)
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
            return "ROAR!!!";
        }
    }
}
