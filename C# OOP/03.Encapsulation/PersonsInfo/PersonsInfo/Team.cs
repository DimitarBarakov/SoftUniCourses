using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return reserveTeam.AsReadOnly(); }
        }


        public IReadOnlyCollection<Person> FirstTeam
        {
            get { return firstTeam.AsReadOnly(); }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public Team(string name)
        {
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
            this.Name = name;
        }


        public void AddPlayer(Person player)
        {
            if (player.Age >= 40)
            {
                reserveTeam.Add(player);
            }
            else
            {
                firstTeam.Add(player);
            }
        }
    }
}
