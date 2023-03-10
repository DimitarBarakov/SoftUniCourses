using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Food;

namespace WildFarm.Factories
{
//    	Vegetable
//	Fruit
//	Meat
//	Seeds

    public class FoodFactory : IFoodFactory
    {
        Food food;
        public Food CreateFood(string[] tokens)
        {
            string type = tokens[0];
            int quantity = int.Parse(tokens[1]);

            switch (type)
            {
                case "Vegetable": food = new Vegetable(quantity); break;
                case "Fruit": food = new Fruit(quantity); break;
                case "Meat": food = new Meat(quantity); break;
                case "Seeds": food = new Seeds(quantity); break;
                default:
                    break;
            }
            return food;
        }
    }
}
