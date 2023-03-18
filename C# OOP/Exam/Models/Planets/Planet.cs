using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;
        private string name;
        private double budget;
        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
        }
        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value; 
            }
        }

        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                this.budget = value;
            }
        }

        public double MilitaryPower => Math.Round(this.CaculateMilitaryPower(), 3);

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        private double CaculateMilitaryPower()
        {
            double totalAmount = this.Army.Sum(a => a.EnduranceLevel) + this.Weapons.Sum(w => w.DestructionLevel);
            if (this.Army.Any(a=>a.GetType().Name == "AnonymousImpactUnit"))
            {
                totalAmount *= 1.3;
            }
            if (this.Weapons.Any(a => a.GetType().Name == "NuclearWeapon"))
            {
                totalAmount *= 1.45;
            }
            return totalAmount;
        }

        public void AddUnit(IMilitaryUnit unit)=>this.units.AddItem(unit);

        public void AddWeapon(IWeapon weapon)=>this.weapons.AddItem(weapon);

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: { Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.AppendLine($"--Forces: {(this.Army.Count == 0?"No units":String.Join(", ",this.Army.Select(a=>a.GetType().Name)))}");
            sb.AppendLine($"--Combat equipment: {(this.Weapons.Count == 0 ? "No weapons" : String.Join(", ", this.Weapons.Select(a => a.GetType().Name)))}");
            sb.Append($"--Military Power: {MilitaryPower}");
            return sb.ToString().Trim();
        }

        public void Profit(double amount)
        {
            this.Budget+=amount;
        }

        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in units.Models)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
