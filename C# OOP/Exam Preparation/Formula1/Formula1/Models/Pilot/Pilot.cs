using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Pilot
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;

        private Pilot()
        {
            this.CanRace = false;
            this.NumberOfWins = 0;
        }
        public Pilot(string fullNmae):this()
        {
            this.FullName = fullNmae;
        }
        public string FullName
        {
            get
            {
                return this.fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid pilot name: { value }.");
                }
                this.fullName = value;
            }
        }


        public IFormulaOneCar Car
        {
            get
            {
                return this.car;
            }
             set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Pilot car can not be null.");
                }
            }
        }

        public int NumberOfWins { get; set; }

        public bool CanRace { get; set; }

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot { this.FullName } has { this.NumberOfWins } wins.";
        }
    }
}
