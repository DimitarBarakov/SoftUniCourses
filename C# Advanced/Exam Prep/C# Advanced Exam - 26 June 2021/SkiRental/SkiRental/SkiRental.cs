using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        private int capacity;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }


        public List<Ski> Data
        {
            get { return data; }
            set { data = value; }
        }
        public SkiRental(string name, int capacity)
        {
            Data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }

        public int Count 
        {  
            get
            { 
               return Data.Count;
            }
        }

        public void Add(Ski ski)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (Data.Any(s=>s.Manufacturer==manufacturer && s.Model == model))
            {
                Ski skiToRemove = Data.Find(s => s.Manufacturer == manufacturer && s.Model == model);
                Data.Remove(skiToRemove);
                return true;
            }
            return false;
        }

        public Ski GetNewestSki()
        {
            if (Data.Count == 0)
            {
                return null;
            }
            else
            {
                int newest = 0;
                foreach (var ski in Data)
                {
                    if (ski.Year >= newest)
                    {
                        newest = ski.Year;
                    }
                }
                return Data.Find(s => s.Year == newest);
            }
        }

        public Ski GetSki(string manufacturer, string model)
        {
            if (Data.Any(s => s.Manufacturer == manufacturer && s.Model == model))
            {
                return Data.Find(s => s.Manufacturer == manufacturer && s.Model == model); 
            }
            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}");
            foreach (var ski in Data)
            {
                sb.AppendLine(ski.ToString());
            }
            return sb.ToString();
        }

    }
}
