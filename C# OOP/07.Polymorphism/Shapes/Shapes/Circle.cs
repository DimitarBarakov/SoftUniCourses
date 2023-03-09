using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle:Shape
    {
        private double redius;

        public double Radius
        {
            get { return redius; }
            set { redius = value; }
        }

        public Circle(double r)
        {
            this.Radius = r;
        }

        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public override double CalculatePerimeter()
        {
            return Math.PI * 2 * this.Radius;
        }

        public override string Draw()
        {
            return "circle";
        }
    }
}
