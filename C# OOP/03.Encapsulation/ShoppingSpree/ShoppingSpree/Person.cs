using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;      

        public List<Product> Products
        {
            get { return products; }
            private set { products = value; }
        }


        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value; 
            }
        }


        public string Name
        {
            get { return name; }
            set 
            { 
                if (value == "")
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value; 
            }
        }

        public Person(string name, decimal money)
        {
            products = new List<Product>();
            this.Name = name;
            this.Money = money;
        }

        public override string ToString()
        {
            if (this.Products.Count > 0)
            {
                return $"{this.Name} - {string.Join(", ", this.Products)}";
            }
            else
            {
                return $"{this.Name} - Nothing bought";
            }
        }
    }
}
