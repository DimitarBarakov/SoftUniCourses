using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animal.Mammal
{
    public class Dog : Mammal
    {
        private const double WeightIncrement = 0.40;
        public Dog(string name, double weight, string livingregion) : base(name, weight, livingregion)
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
            return "Woof!";
        }
    }
}
