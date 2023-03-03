using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private string name;
        private int capacity;
        private List<Player> roaster;

        public List<Player> Roaster
        {
            get { return roaster; }
            set { roaster = value; }
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
        public int Count { get => Roaster.Count; }
        public Guild(string name, int capacity)
        {
            Roaster = new List<Player>();
            Name = name;
            Capacity = capacity;
        }

        public void AddPlayer(Player player)
        {
            if (Roaster.Count < capacity)
            {
                Roaster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (Roaster.Any(p => p.Name == name))
            {
                Roaster.Remove(Roaster.First(p => p.Name == name));
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            Roaster.First(p => p.Name == name).Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            Roaster.First(p => p.Name == name).Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string clas)
        {
            Player[] removedPlayers;
            removedPlayers = Roaster.Where(p => p.Class == clas).ToArray();
            Roaster.RemoveAll(p => p.Class == clas);
            return removedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in Roaster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
