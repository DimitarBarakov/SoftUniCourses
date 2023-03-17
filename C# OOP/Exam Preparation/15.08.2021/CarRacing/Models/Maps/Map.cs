using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            racerOne.Race();
            racerTwo.Race();
            double racerOneWinningChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * (racerOne.RacingBehavior == "strict" ? 1.2 : 1.1);
            double racerTwoWinningChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * (racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1);
            return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, (racerOneWinningChance > racerTwoWinningChance ? racerOne.Username : racerTwo.Username));
        }
    }
}
