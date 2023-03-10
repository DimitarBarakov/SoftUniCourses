﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animal.Birds
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, double wingsize) : base(name, weight)
        {
            this.WingSize = wingsize;
        }

        public double WingSize { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
