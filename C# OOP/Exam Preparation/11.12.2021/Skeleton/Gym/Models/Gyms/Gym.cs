using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public class Gym : IGym
    {
        private string name;
        private int capacity;
        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Equipment = new List<IEquipment>();
            this.Athletes = new List<IAthlete>();
        }
        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value; 
            }
        }

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public double EquipmentWeight => Equipment.Sum(q => q.Weight);
        

        public ICollection<IEquipment> Equipment
        {
            get;
            set;
        }

        public ICollection<IAthlete> Athletes
        {
            get;
            set;
        }

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            this.Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)=> this.Equipment.Add(equipment);

        public void Exercise()
        {
            foreach (var athlete in this.Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{ this.Name} is a { this.GetType().Name }:");
            sb.AppendLine($"Athletes: {(this.Athletes.Count == 0 ? "No athletes" : string.Join(", ",this.Athletes.Select(a=>a.FullName)))}");
            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight:f2} grams");

            return sb.ToString().Trim();
        }

        public bool RemoveAthlete(IAthlete athlete) => this.Athletes.Remove(athlete);
    }
}
