using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        //•	Name: string
        //•	Class: string
        //•	Rank: string – "Trial" by default
        //•	Description: string – "n/a" by default

        private string name;
        private string @class;
        private string rank;
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public string Rank
        {
            get { return rank; }
            set { rank = value; }
        }


        public string @Class
        {
            get { return @class; }
            set { @class = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Player(string name, string clas)
        {
            Name = name;
            Class = clas;
            Rank = "Trial";
            Description = "n/a";
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Player { Name}: { Class }");
            sb.AppendLine($"Rank: {Rank}");
            sb.AppendLine($"Description: {Description}");
            return sb.ToString().TrimEnd(); ;
        }

    }
}
