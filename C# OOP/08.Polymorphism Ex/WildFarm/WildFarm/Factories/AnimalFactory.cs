using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animal;
using WildFarm.Models.Animal.Birds;
using WildFarm.Models.Animal.Mammal;
using WildFarm.Models.Animal.Mammal.Feline;

namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        Animal animal;
        public Animal CreateAnimal(string[] tokens)
        {
            string type = tokens[0];
            string name = tokens[1];
            double weight = double.Parse(tokens[2]);
            if (type == "Cat")
            {
                string livingRegion = tokens[3];
                string breed = tokens[4];
                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                string livingRegion = tokens[3];
                string breed = tokens[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }
            else if (type == "Owl")
            {
                double wingSize = double.Parse(tokens[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(tokens[3]);
                animal = new Hen(name, wingSize, wingSize);
            }
            else if (type == "Dog")
            {
                string livingRegion = tokens[3];
                animal = new Dog(name, weight, livingRegion);
            }
            else if (type == "Mouse")
            {
                string livingRegion = tokens[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            return animal;
        }
    }
}
