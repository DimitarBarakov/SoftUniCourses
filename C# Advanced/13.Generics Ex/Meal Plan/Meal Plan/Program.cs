using System;
using System.Collections.Generic;
using System.Linq;

namespace Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split());
            Stack<int> caloriesPerDay = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int mealsCount = 0;

            while (meals.Count > 0 && caloriesPerDay.Count > 0)
            {
                int currMealCalories = 0;
                string currMeal = meals.Peek();
                switch (currMeal)
                {
                    case "salad": currMealCalories = 350; break;
                    case "soup":currMealCalories = 490; break;
                    case "pasta": currMealCalories = 680; break;
                    case "steak": currMealCalories = 790; break;
                    default:
                        break;
                }

                int currDayCalories = caloriesPerDay.Peek();
                currDayCalories -= currMealCalories;
                meals.Dequeue();
                mealsCount++;
                if (currDayCalories > 0)
                {
                    caloriesPerDay.Pop();
                    caloriesPerDay.Push(currDayCalories);
                }
                else if (currDayCalories == 0)
                {
                    caloriesPerDay.Pop();
                }
                else
                {
                    if (caloriesPerDay.Count <= 1)
                    {
                        break;
                    }
                    else
                    {
                        currDayCalories = -currDayCalories;
                        caloriesPerDay.Pop();
                        int nextDay = caloriesPerDay.Peek() - currDayCalories;
                        caloriesPerDay.Pop();
                        caloriesPerDay.Push(nextDay);
                    }
                }
            }
            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {mealsCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesPerDay)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsCount} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ",meals)}.");
            }
        }
    }
}
