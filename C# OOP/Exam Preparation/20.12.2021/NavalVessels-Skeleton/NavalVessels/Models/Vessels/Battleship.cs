using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Vessels
{
    public class Battleship : Vessel,IBattleship
    {
        private const double initialArmour = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, initialArmour)
        {
            this.SonarMode = false;
        }
        public bool SonarMode { get; private set; }
        public override void RepairVessel()
        {
            this.ArmorThickness = initialArmour;
        }
        public void ToggleSonarMode()
        {
            if (SonarMode)
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
                this.SonarMode = false;
            }
            else
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
                this.SonarMode = true;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Sonar mode: {(this.SonarMode?"ON":"OFF")}");
            return sb.ToString().Trim();
        }
    }
}
