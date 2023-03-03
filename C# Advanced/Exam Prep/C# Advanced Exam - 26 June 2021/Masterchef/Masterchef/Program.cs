using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ingredient = new List<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Dictionary<string,int> meals = new Dictionary<string,int>();
            meals.Add("Dipping sauce",0);
            meals.Add("Green salad", 0);
            meals.Add("Chocolate cake", 0);
            meals.Add("Lobster", 0);

            while (ingredient.Count > 0 && freshness.Count > 0)
            {
                int currIngredient = ingredient[0];
                if (currIngredient == 0)
                {
                    ingredient.RemoveAt(0);
                    continue;
                }
                int currFreshness = freshness.Peek();

                int totalValue = currIngredient * currFreshness;
                if (totalValue == 150)
                {
                    meals["Dipping sauce"]++;
                    ingredient.RemoveAt(0);
                    freshness.Pop();
                }
                else if (totalValue == 250)
                {
                    meals["Green salad"]++;
                    ingredient.RemoveAt(0);
                    freshness.Pop();
                }
                else if (totalValue == 300)
                {
                    meals["Chocolate cake"]++;
                    ingredient.RemoveAt(0);
                    freshness.Pop();
                }
                else if (totalValue == 400)
                {
                    meals["Lobster"]++;
                    ingredient.RemoveAt(0);
                    freshness.Pop();
                }
                else
                {
                    ingredient.Remove(currIngredient);
                    currIngredient += 5;
                    ingredient.Add(currIngredient);
                    freshness.Pop();
                }
            }

            var cookedMeals = meals.Where(m => m.Value > 0).OrderBy(m => m.Key);
            if (cookedMeals.Count() >= 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredient.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredient.Sum()}");
            }
            foreach (var meal in cookedMeals)
            {
                Console.WriteLine($" # {meal.Key} --> {meal.Value}");
            }
        }
    }
}
