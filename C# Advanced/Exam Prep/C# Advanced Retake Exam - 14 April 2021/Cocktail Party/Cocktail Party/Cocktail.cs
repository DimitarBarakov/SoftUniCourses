using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private string name;
        private int capacity;
        private int maxAlcoholLevel;
        private List<Ingredient> ingredients;

        public List<Ingredient> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }


        public int MaxAlcoholLevel
        {
            get { return maxAlcoholLevel; }
            set { maxAlcoholLevel = value; }
        }


        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int CurrentAlcoholLevel
        {
            get
            {
                return Ingredients.Sum(i => i.Alcohol);
            }
        }

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public void Add(Ingredient ingredient)
        {
            if ((Ingredients.Count < Capacity) && (!Ingredients.Any(i => i.Name == ingredient.Name)) && (ingredient.Alcohol <= MaxAlcoholLevel))
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            if (Ingredients.Any(i => i.Name == name))
            {
                Ingredients.Remove(Ingredients.First(i => i.Name == name));
                return true;
            }
            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            if (Ingredients.Any(i => i.Name == name))
            {
                return Ingredients.First(i => i.Name == name);
            }
            return null;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            int maxAlcohol = 0;
            foreach (var item in Ingredients)
            {
                if (item.Alcohol > maxAlcohol)
                {
                    maxAlcohol = item.Alcohol;
                }
            }
            return Ingredients.First(i => i.Alcohol == maxAlcohol);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var item in Ingredients)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
