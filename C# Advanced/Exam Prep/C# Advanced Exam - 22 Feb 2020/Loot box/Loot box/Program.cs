using System;
using System.Collections.Generic;
using System.Linq;

namespace Loot_box
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstBox = Console.ReadLine().Split().Select(int.Parse).ToList();
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());

            int collectedItems = 0;
            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int firstBoxItem = firstBox[0];
                int secondBoxItem = secondBox.Peek();
                int sum = firstBoxItem + secondBoxItem;

                if (sum % 2 == 0)
                {
                    collectedItems += sum;
                    secondBox.Pop();
                    firstBox.RemoveAt(0);
                }
                else
                {
                    firstBox.Add(secondBox.Pop());
                }
            }

            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (collectedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {collectedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {collectedItems}");
            }
        }
    }
}
