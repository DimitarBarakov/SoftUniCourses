using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main()
        {
            Shape shape = new Rectangle(3, 4);
            Shape shape1 = new Circle(5);

            Console.WriteLine(shape.CalculatePerimeter());
            Console.WriteLine(shape.CalculateArea());
            Console.WriteLine(shape.Draw());

            Console.WriteLine(shape1.CalculatePerimeter());
            Console.WriteLine(shape1.CalculateArea());
            Console.WriteLine(shape1.Draw());
        }
    }
}
