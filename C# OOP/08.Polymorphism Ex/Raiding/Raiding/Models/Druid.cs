using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Druid:BaseHero
    {
        private const int DefaultPower = 80;

        private string name;

        public Druid(string name):base(name)
        {
            this.Power = DefaultPower;
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
