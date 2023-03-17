using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Vessels
{
    public class Submarine : Vessel,ISubmarine
    {
        private const int initialArmor = 200;
        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, initialArmor)
        {
            SubmergeMode = false;
        }
        public bool SubmergeMode { get; private set; }
        public override void RepairVessel()
        {
            this.ArmorThickness = initialArmor;
        }
        public void ToggleSubmergeMode()
        {
            if (SubmergeMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
                this.SubmergeMode = false;
            }
            else
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
                this.SubmergeMode = true;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"* Submerge mode: {(this.SubmergeMode ? "ON" : "OFF")}");
            return sb.ToString().Trim();
        }
    }
}
