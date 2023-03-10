using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Paladin:BaseHero
    {
        private const int DefaultPower = 100;

        public Paladin(string name) : base(name)
        {
            this.Power = DefaultPower;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
