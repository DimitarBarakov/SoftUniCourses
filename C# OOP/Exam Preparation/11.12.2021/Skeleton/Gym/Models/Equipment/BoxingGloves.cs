using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double initialWeight = 227;
        private const decimal initialPrice = 120m;
        public BoxingGloves() : base(initialWeight, initialPrice)
        {
        }
    }
}
