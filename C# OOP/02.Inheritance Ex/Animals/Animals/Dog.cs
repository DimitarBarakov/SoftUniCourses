using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog:Animal
    {
        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
