using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Models.Pilot;
using Formula1.Models.Race;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    internal class Controller : IController
    {
        private FormulaOneCarRepository carRepository;
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;

        public Controller()
        {
            carRepository = new FormulaOneCarRepository();
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (!pilotRepository.Models.Any(p=>p.FullName == pilotName) || pilotRepository.Models.FirstOrDefault(p => p.FullName == pilotName).Car != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage,pilotName));
            }
            if (!carRepository.Models.Any(c=>c.Model == carModel))
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            Pilot pilot = (Pilot)pilotRepository.Models.First(p => p.FullName == pilotName);
            IFormulaOneCar car = carRepository.Models.First(p => p.Model == carModel);
            pilot.Car = car;
            pilot.CanRace = true;
            return String.Format(OutputMessages.SuccessfullyPilotToCar,pilot.FullName, car.GetType().Name, car.Model);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            Race race = (Race)raceRepository.Models.First(r => r.RaceName == raceName);
            Pilot pilot = (Pilot)pilotRepository.Models.First(r => r.FullName == pilotFullName);
            if (!raceRepository.Models.Any(r=>r.RaceName == raceName))
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            if (!pilotRepository.Models.Contains(pilot) || !pilot.CanRace || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            race.Pilots.Add(pilot);
            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (type!= "Ferrari" && type!= "Williams")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            if (carRepository.Models.Any(c => c.Model == model))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            IFormulaOneCar car;
            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }

            
            carRepository.Add(car);
            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.Models.Any(p=>p.FullName == fullName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage,fullName));
            }
            pilotRepository.Add(new Pilot(fullName));
            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.Models.Any(r=>r.RaceName == raceName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            Race raceToAdd = new Race(raceName, numberOfLaps);
            raceRepository.Add(raceToAdd);
            return String.Format(OutputMessages.SuccessfullyCreateRace,raceName);
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            List<IPilot> pilots = pilotRepository.Models.OrderByDescending(p => p.NumberOfWins).ToList();
            foreach (var pilot in pilots)
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            List<IRace> executedRaces = raceRepository.Models.Where(r=>r.TookPlace == true).ToList();
            foreach (var race in executedRaces)
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            if (!raceRepository.Models.Any(r=>r.RaceName==raceName))
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            if (raceRepository.Models.First(r => r.RaceName == raceName).Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (raceRepository.Models.First(r => r.RaceName == raceName).TookPlace == true)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }


            Race race = (Race)raceRepository.Models.First(r => r.RaceName == raceName);
            //foreach (Pilot racer in race.Pilots)
            //{
            //    racer.Car.RaceScoreCalculator(race.NumberOfLaps);
            //}
            race.Pilots = race.Pilots.OrderBy(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
            race.TookPlace = true;
            Pilot winner = (Pilot)race.Pilots.First();
            winner.WinRace();
            Pilot second = (Pilot)race.Pilots.ToList()[1];
            Pilot third = (Pilot)race.Pilots.ToList()[2];
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format(OutputMessages.PilotFirstPlace, winner, race.RaceName));
            sb.AppendLine(String.Format(OutputMessages.PilotSecondPlace, second, race.RaceName));
            sb.AppendLine(String.Format(OutputMessages.PilotThirdPlace, third, race.RaceName));

            return sb.ToString().TrimEnd();
        }
    }
}
