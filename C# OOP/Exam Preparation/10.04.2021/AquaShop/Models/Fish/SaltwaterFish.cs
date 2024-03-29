﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int initialSize = 5;
        private const int increasingSize = 2;
        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = initialSize;
        }

        public override void Eat()
        {
            this.Size += increasingSize;
        }
    }
}
