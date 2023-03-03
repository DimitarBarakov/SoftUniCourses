using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public List<Car> Participants = new List<Car>();
        //•	Name: string
        //•	Type: string
        //•	Laps: int
        //•	Capacity: int
        //•	MaxHorsePower: int 
        private string name;
        private string type;
        private int laps;
        private int capacity;
        private int maxHorsePower;

        public int MaxHorsePower
        {
            get { return maxHorsePower; }
            set { maxHorsePower = value; }
        }


        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }


        public int Laps
        {
            get { return laps; }
            set { laps = value; }
        }


        public string Type
        {
            get { return type; }
            set { type = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Count { get { return Participants.Count; } }

        public Race(string name, string type, int laps, int capacity,int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }


        public void Add(Car car)
        {
            if ((!Participants.Any(c=>c.LicensePlate==car.LicensePlate)) && (Participants.Count < this.Capacity) && (car.HorsePower <= this.MaxHorsePower))
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string license)
        {
            if (Participants.Any(c => c.LicensePlate == license))
            {
                Car carToRemove = Participants.Find(c => c.LicensePlate == license);
                Participants.Remove(carToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Car FindParticipant(string licensePlate)
        {
            if (Participants.Any(c => c.LicensePlate == licensePlate))
            {
                return Participants.Find(c => c.LicensePlate == licensePlate);
            }
            else
            {
                return null;
            }
        }

        public Car GetMostPowerfulCar()
        {
            if (Participants.Count == 0)
            {
                return null;
            }
            else
            {
                int maxHorsePower = 0;
                foreach (var car in Participants)
                {
                    if (car.HorsePower >= maxHorsePower)
                    {
                        maxHorsePower = car.HorsePower;
                    }
                }
                return Participants.Find(c => c.HorsePower == maxHorsePower);
            }
        }

        public string Report()
        {
           StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var car in Participants)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString();
        }
    }   
}
