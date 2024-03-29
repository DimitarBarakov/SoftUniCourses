﻿using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;
        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.EnduranceLevel = 1;
        }
        public double Cost
        {
            get { return cost; }
            private set { cost = value; }
        }

        public int EnduranceLevel
        {
            get { return enduranceLevel; }
            private set { enduranceLevel = value;}
        }

        public void IncreaseEndurance()
        {
            this.EnduranceLevel++;
            if (this.EnduranceLevel > 21)
            {
                this.EnduranceLevel = 20;
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}
