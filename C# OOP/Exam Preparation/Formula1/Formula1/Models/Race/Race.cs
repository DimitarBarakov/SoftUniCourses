using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Race
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;
        private ICollection<IPilot> pilots;

        private Race()
        {
            this.TookPlace = false;
            this.Pilots = new List<IPilot>();
        }
        public Race(string raceName, int numberOfLaps):this()
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
        }
        public string RaceName
        {
            get { return raceName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: { value }.");
                }
                raceName = value; 
            }
        }

        public int NumberOfLaps
        {
            get { return numberOfLaps; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: { value }.");
                }
                this.numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set ; }

        public ICollection<IPilot> Pilots { get { return this.pilots; }  set { this.pilots = value; } }

        public void AddPilot(IPilot pilot)
        {
            this.Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The { this.RaceName } race has:");
            sb.AppendLine($"Participants: { this.Pilots.Count }");
            sb.AppendLine($"Number of laps: { this.NumberOfLaps }");
            sb.AppendLine($"Took place: { this.TookPlace }");

            return sb.ToString().TrimEnd();
        }
    }
}
