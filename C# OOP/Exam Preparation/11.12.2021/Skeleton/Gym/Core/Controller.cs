using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Equipment;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var gym = gyms.FirstOrDefault(g => g.Name == gymName);
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            if (athleteType == "Boxer" && gym.GetType().Name == "BoxingGym")
            {
                var athlete = new Boxer(athleteName, motivation, numberOfMedals);
                gym.AddAthlete(athlete);
                return String.Format(OutputMessages.EntityAddedToGym, athleteType, gym.Name);
            }
            else if (athleteType == "Weightlifter" && gym.GetType().Name == "WeightliftingGym")
            {
                var athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                gym.AddAthlete(athlete);
                return String.Format(OutputMessages.EntityAddedToGym, athleteType, gym.Name);
            }
            else
            {
                return OutputMessages.InappropriateGym;
            }
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == "BoxingGloves")
            {
                var eq = new BoxingGloves();
                this.equipment.Add(eq);
                return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
            }
            else if (equipmentType == "Kettlebell")
            {
                var eq = new Kettlebell();
                this.equipment.Add(eq);
                return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType == "BoxingGym")
            {
                var gym = new BoxingGym(gymName);
                gyms.Add(gym);
                return String.Format(OutputMessages.SuccessfullyAdded, gymType);
            }
            else if (gymType == "WeightliftingGym")
            {
                var gym = new WeightliftingGym(gymName);
                gyms.Add(gym);
                return String.Format(OutputMessages.SuccessfullyAdded, gymType);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.FirstOrDefault(g => g.Name == gymName);
            double equipmentWeight = gym.EquipmentWeight;

            return String.Format(OutputMessages.EquipmentTotalWeight,gymName, equipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var eq = equipment.FindByType(equipmentType);
            if (eq == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            var gym = gyms.FirstOrDefault(g => g.Name == gymName);
            gym.AddEquipment(eq);
            equipment.Remove(eq);
            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            var gym = gyms.FirstOrDefault(g => g.Name == gymName);
            foreach (var athlete in gym.Athletes)
            {
                athlete.Exercise();
            }
            return String.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
