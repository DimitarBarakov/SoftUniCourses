using System.Collections.Generic;

namespace Zoo
{
    public class Zoo
    {
       public List<Animal> Animals = new List<Animal>();


        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
        public string Name { get; set; }

        public int Capacity { get; set; }
        

        public string AddAnimal(Animal animal)
        {
            if (animal.Species == " " || animal.Species == null)
            {
                return "Invalid animal species.";
            }
            else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            else if (Animals.Count == this.Capacity)
            {
                return "The zoo is full.";
            }
            else
            {
                Animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }
        }

        public int RemoveAnimals(string species)
        {
            int originalCount = Animals.Count;
            Animals.RemoveAll(animal => animal.Species == species);
            int countAfterRemoving = Animals.Count;
            int removedCount = originalCount - countAfterRemoving;
            return removedCount;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return Animals.FindAll(animal => animal.Diet == diet);
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.Find(animal => animal.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count =  Animals.FindAll(animal => animal.Length >= minimumLength && animal.Length <= maximumLength).Count;
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
