using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Gym.Models.Athletes
{
    public abstract class Athelete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int stamina;
        private int medals;

        public Athelete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.NumberOfMedals = numberOfMedals;
            this.FullName = fullName;
            this.Motivation = motivation;
            this.Stamina = stamina;
        }

        public string FullName
        {
            get { return fullName; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }
                fullName = value; 
            }
        }

        public string Motivation
        {
            get { return motivation; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }
                motivation = value;
            }
        }

        public int Stamina
        {
            get { return stamina; }
            set { stamina = value; }
        }

        public int NumberOfMedals
        {
            get { return medals; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }
                medals = value;
            }
        }

        public abstract void Exercise();
        
    }
}
