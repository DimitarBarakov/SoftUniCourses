using System;
using WildFarm.Core;
using WildFarm.Models.Animal.Birds;
using WildFarm.Models.Animal.Mammal;
using WildFarm.Models.Animal.Mammal.Feline;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Start();
        }
    }
}
