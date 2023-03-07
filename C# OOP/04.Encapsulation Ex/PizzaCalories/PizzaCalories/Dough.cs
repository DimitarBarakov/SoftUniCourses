using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string technique;
        private double grams;

        public double Grams
        {
            get { return grams; }
            private set
            {
                if (value<1||value>200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                grams = value; 
            }
        }


        public Dough(string flourtype, string technique, double grams)
        {
            this.Technique = technique;
            this.Grams = grams;
            this.FlourType = flourtype;
        }

        public string Technique
        {
            get { return technique; }
            private set
            {
                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                technique = value; 
            }
        }


        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (value != "white" && value != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }

        public double CalculateCalories()
        {
            double flourTypeCalories = 0;
            switch (FlourType)
            {
                case "white": flourTypeCalories = 1.5; break;
                case "wholegrain": flourTypeCalories = 1.0; break;
            }
            double technoqueCalories = 0;
            switch (Technique)
            {
                case "crispy": technoqueCalories = 0.9; break;
                case "chewy": technoqueCalories = 1.1; break;
                case "homemade": technoqueCalories = 1.0; break;
                default:
                    break;
            }
            double calculatedCalories = this.Grams * 2 * flourTypeCalories * technoqueCalories;
            return calculatedCalories;
        }

    }
}
