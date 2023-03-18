using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon:Weapon
    {
        private int destr;
        private const double price = 3.2;
        public BioChemicalWeapon(int destructionLevel):base(destructionLevel,price)
        {
            this.DestructionLevel = destructionLevel;
        }

        public override int DestructionLevel
        {
            get
            {
                return destr;
            }
            protected set
            {
                if (value<1)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }
                else if (value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }
                destr = value;
            }
        }
    }
}
