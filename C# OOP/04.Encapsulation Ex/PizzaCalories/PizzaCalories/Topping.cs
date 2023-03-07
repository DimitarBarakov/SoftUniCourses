using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double grams;

        public double Grams
        {
            get { return grams; }
            set
            {
                if (value <= 0 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }
                grams = value; 
            }
        }


        public string Type
        {
            get { return type; }
            set
            {
                if (value != "meat" && value != "veggies" && value != "cheese" && value != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value; 
            }
        }

        public Topping(string type, double grams)
        {
            this.Type = type;
            this.Grams = grams;
        }
        public double Calories => CalculateCalories();

        public double CalculateCalories()
        {
            double typeCalories = 0;
            switch (this.Type)
            {
                case "meat": typeCalories = 1.2; break;
                case "veggies": typeCalories = 0.8; break;
                case "cheese": typeCalories = 1.1; break;
                case "sauce": typeCalories = 0.9; break;
                default:
                    break;
            }

            double calculatedCalories = this.Grams * 2 * typeCalories;
            return calculatedCalories;
        }
    }
}
