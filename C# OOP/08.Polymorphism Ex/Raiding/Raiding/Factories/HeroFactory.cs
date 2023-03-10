using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories
{
    internal class HeroFactory : IHero
    {
        BaseHero hero;
        public BaseHero CreateHero(string type, string name)
        {
            if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new ArgumentException();
            }

            return hero;
        }
    }
}
