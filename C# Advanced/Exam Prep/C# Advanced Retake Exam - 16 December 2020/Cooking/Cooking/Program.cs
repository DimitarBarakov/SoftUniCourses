using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> foods = new Dictionary<string, int>();
            foods.Add("Bread", 0);
            foods.Add("Cake", 0);
            foods.Add("Pastry", 0);
            foods.Add("Fruit Pie", 0);
            foods = foods.OrderBy(f => f.Key).ToDictionary(f=>f.Key, f=>f.Value);

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currLiquid = liquids.Peek();
                int currIngredient = ingredients.Peek();
                int mix = currIngredient + currLiquid;

                if (mix == 25)
                {
                    foods["Bread"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (mix == 50)
                {
                    foods["Cake"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (mix == 75)
                {
                    foods["Pastry"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (mix == 100)
                {
                    foods["Fruit Pie"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    currIngredient += 3;
                    ingredients.Push(currIngredient);
                }
            }
            var cookedFood = foods.Where(f => f.Value > 0).OrderBy(f=>f.Key);
            if (cookedFood.Count() == 4)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",liquids)}");
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            foreach (var food in foods)
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }
    }
}
