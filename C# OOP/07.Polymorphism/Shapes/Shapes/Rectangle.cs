using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double h, double w)
        {
            this.Height = h;
            this.Width = w;
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }


        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Height + this.Width);
        }

        public override string Draw()
        {
            return "Rectangle";
        }
    }
}
