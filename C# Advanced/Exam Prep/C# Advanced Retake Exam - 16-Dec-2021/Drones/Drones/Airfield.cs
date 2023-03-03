using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones = new List<Drone>();
        private string name;
        private int capacity;
        private double myVar;

        public double LandingStrip
        {
            get { return myVar; }
            set { myVar = value; }
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

        public int Count
        {
            get
            {
                return Drones.Count;
            }
        }

        public Airfield(string name, int capacity, double landingstrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingstrip;
        }

        public string AddDrone(Drone drone)
        {
            if (drone.Name == null || drone.Brand == "")
            {
                return "Invalid drone.";
            }
            else if (drone.Range <= 5 || drone.Range >= 15)
            {
                return "Invalid drone.";
            }
            else if (Drones.Count == Capacity)
            {
                return "Airfield is full.";
            }
            else
            {
                Drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }
        }
        public bool RemoveDrone(string name)
        {
            if (Drones.Any(d=>d.Name == name))
            {
                Drone droneToRemove = Drones.Find(d => d.Name == name);
                Drones.Remove(droneToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int RemoveDroneByBrand(string brand)
        {
            List<Drone> toRemove = Drones.Where(d => d.Brand == brand).ToList();
            Drones.RemoveAll(d => d.Brand == brand);
            return toRemove.Count;
        }
        public Drone FlyDrone(string name)
        {
            if (!Drones.Any(d => d.Name == name))
            {
                return null;
            }
            else
            {
                Drones.Find(d => d.Name == name).Available = false;
                Drone drone = Drones.Find(d => d.Name == name);
                return drone;
            }


        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flown = Drones.Where(d => d.Range >= range).ToList();
            foreach (var drone in flown)
            {
                drone.Available = false;
            }
            return flown;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at { this.Name}:");
            Drones = Drones.Where(d => d.Available==true).ToList();
            foreach (var item in Drones)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
