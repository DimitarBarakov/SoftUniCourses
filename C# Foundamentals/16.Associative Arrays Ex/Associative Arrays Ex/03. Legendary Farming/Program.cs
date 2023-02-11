using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    internal class Program
    {
        public static object DIctionary { get; private set; }

        static void Main(string[] args)
        {
            Dictionary<string, int> collectedResourses = new Dictionary<string, int>();
            collectedResourses.Add("shards", 0);
            collectedResourses.Add("motes", 0);
            collectedResourses.Add("fragments", 0);

            while (collectedResourses["shards"] < 250 && collectedResourses["motes"] < 250 && collectedResourses["fragments"] < 250)
            {
                string[] items = Console.ReadLine().Split().ToArray();
                for (int i = 1; i < items.Length; i+=2)
                {
                    string value = items[i].ToLower();
                    int quantity = int.Parse(items[i - 1]);
                    if (collectedResourses.ContainsKey(value))
                    {
                        collectedResourses[value] += quantity;
                        if (!((collectedResourses["shards"] < 250) && (collectedResourses["motes"] < 250) && (collectedResourses["fragments"] < 250)))
                        {
                            break;
                        }
                    }
                    else
                    {
                        collectedResourses.Add(value, quantity);
                    }
                }
                if (!((collectedResourses["shards"] < 250) && (collectedResourses["motes"] < 250) && (collectedResourses["fragments"] < 250)))
                {
                    break;
                }
            }
            if (collectedResourses["shards"] >= 250)
            {
                collectedResourses["shards"] -= 250;
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (collectedResourses["motes"] >= 250)
            {
                collectedResourses["motes"] -= 250;
                Console.WriteLine("Dragonwrath obtained!");
            }
            else if (collectedResourses["fragments"] >= 250)
            {
                collectedResourses["fragments"] -= 250;
                Console.WriteLine("Valanyr obtained!");
            }
            foreach (var item in collectedResourses)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
