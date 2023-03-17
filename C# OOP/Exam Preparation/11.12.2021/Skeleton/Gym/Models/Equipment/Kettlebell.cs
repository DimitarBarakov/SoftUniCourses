using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class Kettlebell:Equipment
    {
        private const double initialWeight = 10000;
        private const decimal initialPrice = 80m;
        public Kettlebell() : base(initialWeight, initialPrice)
        {
        }
    }
}
