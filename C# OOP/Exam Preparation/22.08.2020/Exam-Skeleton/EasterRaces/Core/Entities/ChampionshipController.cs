using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository cars;
        private DriverRepository drivers;
        private RaceRepository reaces;
        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.reaces = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = cars.GetByName(carModel);
            IDriver driver = drivers.GetByName(driverName);
            if (car == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, carModel));
            }
            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            driver.AddCar(car);
            return String.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = reaces.GetByName(raceName);
            IDriver driver = drivers.GetByName(driverName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            race.AddDriver(driver);
            return String.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = cars.GetByName(model);
            if (car != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarExists, model));
            }
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
                cars.Add(car);
                return String.Format(OutputMessages.CarCreated, "MuscleCar", model);
            }
            car = new SportsCar(model, horsePower);
            cars.Add(car);
            return String.Format(OutputMessages.CarCreated, "SportsCar", model);
        }

        public string CreateDriver(string driverName)
        {
            var driver = drivers.GetByName(driverName);
            if (driver == null)
            {
                driver = new Driver(driverName);
                drivers.Add(driver);
                return String.Format(OutputMessages.DriverCreated, driverName);
            }
            throw new ArgumentException(String.Format(ExceptionMessages.DriversExists, driverName));
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = reaces.GetByName(name);
            if (race == null)
            {
                race = new Race(name, laps);
                reaces.Add(race);
                return String.Format(OutputMessages.RaceCreated, name);
            }
            throw new ArgumentException(ExceptionMessages.RaceExists, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = reaces.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }
            List<IDriver> ordered = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).ToList();
            ordered[0].WinRace();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Driver {ordered[0].Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {ordered[1].Name} is second in {race.Name} race.");
            sb.AppendLine($"Driver {ordered[2].Name} is third in {race.Name} race.");
            return sb.ToString().Trim();
        }
    }
}
