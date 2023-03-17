using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Gyms
{
    internal class WeightliftingGym:Gym
    {
        private const int initialCApacity = 20;
        public WeightliftingGym(string name) : base(name, initialCApacity)
        {
        }
    }
}
