using System;
using System.Collections.Generic;
using System.Text;

namespace SkiRental
{
    public class Ski
    {
        private string manufacturer;
        private string model;
        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }


        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public Ski(string manufacturer,string model,int year )
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Manufacturer} - {Model} - {Year}";
        }
    }
}
