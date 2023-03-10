using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Warrior:BaseHero
    {
        private const int DefaultPower = 100;
        public Warrior(string name) : base(name)
        {
            this.Power = DefaultPower;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
