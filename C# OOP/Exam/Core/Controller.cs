using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            this.planets = new PlanetRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            IMilitaryUnit unit;
            if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            if (planet.Army.Any(a => a.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }
            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            IWeapon unit;
            if (weaponTypeName == "NuclearWeapon")
            {
                unit = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                unit = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == "BioChemicalWeapon")
            {
                unit = new BioChemicalWeapon(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
            if (planet.Army.Any(a => a.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }
            planet.Spend(unit.Price);
            planet.AddWeapon(unit);
            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            Planet planet = (Planet)planets.FindByName(name);
            if (planet == null)
            {
                planet = new Planet(name, budget);
                planets.AddItem((IPlanet)planet);
                return String.Format(OutputMessages.NewPlanet, name);
            }
            return String.Format(OutputMessages.ExistingPlanet, name);
        }

        public string ForcesReport()
        {
            List<IPlanet> ordered = planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var pl in ordered)
            {
                sb.AppendLine(pl.PlanetInfo());
            }
            return sb.ToString().Trim();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet planet1 = planets.FindByName(planetOne);
            IPlanet planet2 = planets.FindByName(planetTwo);
            IPlanet winner;
            IPlanet loser;
            double loserArmyCosts;
            double loserwEAPONSCosts;
            double total;


            if (planet1.MilitaryPower == planet2.MilitaryPower)
            {
                if (planet1.Weapons.Any(w => w.GetType().Name == "NuclearWeapon") && planet2.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);
                    return OutputMessages.NoWinner;
                }
                else if (!planet1.Weapons.Any(w => w.GetType().Name == "NuclearWeapon") && !planet2.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);
                    return OutputMessages.NoWinner;
                }
                else if (!planet1.Weapons.Any(w => w.GetType().Name == "NuclearWeapon") && planet2.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    winner = planet2;
                    loser = planet1;
                    winner.Spend(winner.Budget / 2);
                    winner.Profit(loser.Budget / 2);
                    loserArmyCosts = loser.Army.Sum(a => a.Cost);
                    loserwEAPONSCosts = loser.Weapons.Sum(a => a.Price);
                    total = loserArmyCosts + loserwEAPONSCosts;
                    winner.Profit(total);
                    planets.RemoveItem(loser.Name);
                    return String.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
                }
                else if (planet1.Weapons.Any(w => w.GetType().Name == "NuclearWeapon") && !planet2.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    winner = planet1;
                    loser = planet2;
                    winner.Spend(winner.Budget / 2);
                    winner.Profit(loser.Budget / 2);
                    loserArmyCosts = loser.Army.Sum(a => a.Cost);
                    loserwEAPONSCosts = loser.Weapons.Sum(a => a.Price);
                    total = loserArmyCosts + loserwEAPONSCosts;
                    winner.Profit(total);
                    planets.RemoveItem(loser.Name);
                    return String.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
                }
            }
            else if (planet1.MilitaryPower > planet2.MilitaryPower)
            {
                winner = planet1;
                loser = planet2;
                winner.Spend(winner.Budget / 2);
                winner.Profit(loser.Budget / 2);
                loserArmyCosts = loser.Army.Sum(a => a.Cost);
                loserwEAPONSCosts = loser.Weapons.Sum(a => a.Price);
                total = loserArmyCosts + loserwEAPONSCosts;
                winner.Profit(total);
                planets.RemoveItem(loser.Name);
                return String.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
            }

            winner = planet2;
            loser = planet1;
            winner.Spend(winner.Budget / 2);
            winner.Profit(loser.Budget / 2);
            loserArmyCosts = loser.Army.Sum(a => a.Cost);
            loserwEAPONSCosts = loser.Weapons.Sum(a => a.Price);
            total = loserArmyCosts + loserwEAPONSCosts;
            winner.Profit(total);
            planets.RemoveItem(loser.Name);
            return String.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }
            planet.TrainArmy();
            planet.Spend(1.25);
            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
