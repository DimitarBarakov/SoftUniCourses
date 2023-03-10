using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animal;

namespace WildFarm.Factories
{
    public interface IAnimalFactory
    {
        Animal CreateAnimal(string[] tokens);
    }
}
