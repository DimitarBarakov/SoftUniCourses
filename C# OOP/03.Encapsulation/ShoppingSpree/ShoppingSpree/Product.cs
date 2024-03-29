﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public decimal Cost
        {
            get { return cost; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                cost = value;
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

        public Product(string name,decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
