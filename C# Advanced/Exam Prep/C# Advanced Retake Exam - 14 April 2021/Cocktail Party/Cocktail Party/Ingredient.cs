using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        private string name;
        private int alcohol;
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }


        public int Alcohol
        {
            get { return alcohol; }
            set { alcohol = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Ingredient: {Name}");
            sb.AppendLine($"Quantity: {Quantity}");
            sb.AppendLine($"Alcohol: {Alcohol}");
            return sb.ToString().TrimEnd();
        }
    }
}
