using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type == "SuperCar")
            {
                SuperCar car = new SuperCar(make, model, VIN, horsePower);
                cars.Add(car);
                return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
            }
            else if (type == "TunedCar")
            {
                TunedCar car = new TunedCar(make, model, VIN, horsePower);
                cars.Add(car);
                return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.FindBy(carVIN);
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }
            if (type == "StreetRacer")
            {
                StreetRacer racer = new StreetRacer(username, car);
                racers.Add(racer);
                return String.Format(OutputMessages.SuccessfullyAddedRacer, username);
            }
            else if (type == "ProfessionalRacer")
            {
                ProfessionalRacer racer = new ProfessionalRacer(username, car);
                racers.Add(racer);
                return String.Format(OutputMessages.SuccessfullyAddedRacer, username);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername);
            IRacer racerTwo = racers.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }
            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            IReadOnlyCollection<IRacer> orderedRacers = racers.Models.OrderByDescending(r => r.DrivingExperience).ThenBy(r => r.Username).ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var racer in orderedRacers)
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }
            return sb.ToString().Trim();
        }
    }
}
