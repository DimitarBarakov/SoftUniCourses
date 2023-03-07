using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Toppings = new List<Topping>(); 
            this.Name = name;
        }

        public List<Topping> Toppings
        {
            get { return toppings; }
            set { toppings = value; }
        }


        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }


        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value; 
            }
        }

        public int NumberOfToppings
        {
            get => Toppings.Count;
        }

        public void AddTopping(Topping top)
        {
            if (NumberOfToppings == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            else
            {
                this.Toppings.Add(top);
            }
        }

        public double CalculateTotalCalories()
        {
            double totalCalories = this.Dough.CalculateCalories();
            foreach (var top in Toppings)
            {
                totalCalories += top.CalculateCalories();
            }
            return totalCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {CalculateTotalCalories():f2} Calories.";
        }
    }
}
