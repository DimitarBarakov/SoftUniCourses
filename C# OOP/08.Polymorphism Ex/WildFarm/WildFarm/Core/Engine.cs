using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Factories;
using WildFarm.Models.Animal;
using WildFarm.Models.Food;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private List<Animal> animals;

        public Engine()
        {
            this.Animals = new List<Animal>();
        }
       
        public List<Animal> Animals
        {
            get { return animals; }
            set { animals = value; }
        }

        public void Start()
        {
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] animalInfo = cmd.Split();
                string[] foodInfo = Console.ReadLine().Split();

                AnimalFactory animalFactory = new AnimalFactory();
                Animal animal = animalFactory.CreateAnimal(animalInfo);
                this.Animals.Add(animal);

                FoodFactory foodFactory = new FoodFactory();
                Food food = foodFactory.CreateFood(foodInfo);

                Console.WriteLine(animal.Sound());
                animal.Feed(food.GetType().Name, food.Quantity);
            }
            foreach (var animal in Animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
