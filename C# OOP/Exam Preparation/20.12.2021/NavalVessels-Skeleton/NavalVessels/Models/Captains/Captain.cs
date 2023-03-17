using NavalVessels.Models.Contracts;
using NavalVessels.Models.Vessels;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Captains
{
    public class Captain : ICaptain
    {
        private string name;

        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.CombatExperience = 0;
            this.Vessels = new List<IVessel>();
        }
        public string FullName
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                name = value; 
            }
        }

        public int CombatExperience
        {
            get;private set;
        }

        public ICollection<IVessel> Vessels { get; private set; }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");
            if (Vessels.Count > 0)
            {
                foreach (var vessel in Vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }
            return sb.ToString().Trim();
        }
    }
}
