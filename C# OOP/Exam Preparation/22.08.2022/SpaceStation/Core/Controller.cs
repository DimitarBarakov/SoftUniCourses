using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private int exploredPlanets = 0;
        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            if (type == "Biologist")
            {
                Biologist biologist = new Biologist(astronautName);
                astronauts.Add(biologist);
                return String.Format(OutputMessages.AstronautAdded, type, astronautName);
            }
            else if (type == "Geodesist")
            {
                Geodesist geodesist = new Geodesist(astronautName);
                astronauts.Add(geodesist);
                return String.Format(OutputMessages.AstronautAdded, type, astronautName);
            }
            else if (type == "Meteorologist")
            {
                Meteorologist meteorologist = new Meteorologist(astronautName);
                astronauts.Add(meteorologist);
                return String.Format(OutputMessages.AstronautAdded, type, astronautName);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidAstronautType);
            }

        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);
            planet.Items = items.ToList();
            planets.Add(planet);
            return String.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> suitableastronauts = astronauts.Models.Where(a => a.Oxygen > 60).ToList();
            if (suitableastronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            IPlanet planet = planets.FindByName(planetName);
            Mission mission = new Mission();
            mission.Explore(planet, suitableastronauts);
            exploredPlanets++;
            int deathAstronauts = suitableastronauts.Where(a => a.Oxygen <= 0).Count();
            return String.Format(OutputMessages.PlanetExplored, planetName, deathAstronauts);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.AppendLine($"Bag items: {(astronaut.Bag.Items.Count == 0 ? "none" : String.Join(", ", astronaut.Bag.Items))}");
            }

            return sb.ToString().Trim();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            astronauts.Remove(astronaut);
            return String.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
