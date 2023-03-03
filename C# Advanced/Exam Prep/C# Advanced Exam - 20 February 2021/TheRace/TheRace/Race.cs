using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private string name;
        private int capacity;
        private List<Racer> data;

        public List<Racer> Data
        {
            get { return data; }
            set { data = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Count { get => Data.Count; }

        public Race(string name, int capacity)
        {
            Data = new List<Racer>();
            Name = name;
            Capacity = capacity;
        }

        public void Add(Racer Racer)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(Racer);
            }
        }

        public void Remove(string name)
        {
            if (Data.Any(r => r.Name == name))
            {
                Data.Remove(Data.First(r => r.Name == name));
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }

        public Racer GetOldestRacer()
        {
            int oldestAge = 0;
            foreach (var racer in Data)
            {
                if (racer.Age > oldestAge)
                {
                    oldestAge = racer.Age;
                }
            }
            return Data.First(r => r.Age == oldestAge);
        }

        public Racer GetRacer(string name)
        {
            return Data.First(r => r.Name == name);
        }

        public Racer GetFastestRacer()
        {
            int highestSpeed = 0;
            foreach (var racer in Data)
            {
                if (racer.Car.Speed > highestSpeed)
                {
                    highestSpeed = racer.Car.Speed;
                }
            }
            return Data.First(r => r.Car.Speed == highestSpeed);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (var racer in Data)
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString().TrimEnd();
        }


    }
}
