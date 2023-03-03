using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish = new List<Fish>();

        private string material;
        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }


        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
        }

        private int count;

        public int Count
        {
            get { return Fish.Count; }
        }

        public string AddFish(Fish fish)
        {
            if (fish.FishType == null || fish.FishType == " ")
            {
                return "Invalid fish.";
            }
            else if (fish.Weight <= 0 || fish.Length <= 0)
            {
                return "Invalid fish.";
            }
            else if (Fish.Count == Capacity)
            {
                return "Fishing net is full.";
            }
            else
            {
                Fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }
        }
        public bool ReleaseFish(double weight)
        {
            Fish tempFish = new Fish();
            foreach (var item in Fish)
            {
                if (item.Weight == weight)
                {
                    tempFish = item;
                }
            }
            if (tempFish.FishType == null)
            {
                return false;
            }
            else
            {
                Fish.Remove(tempFish);
                return true;
            }
        }
        public Fish GetFish(string fishType)
        {
            return Fish.Find(f => f.FishType == fishType);
        }
        public Fish GetBiggestFish()
        {
            List<Fish> temp = Fish.OrderByDescending(f => f.Length).ToList();
            return temp.First();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");
            Fish = Fish.OrderByDescending(x => x.Length).ToList();
            foreach (var item in Fish)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
