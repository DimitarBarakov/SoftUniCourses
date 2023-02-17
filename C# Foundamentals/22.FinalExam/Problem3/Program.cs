using System;
using System.Collections.Generic;

namespace Problem3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> heroesAndSpells = new Dictionary<string, List<string>>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] tokens = cmd.Split();
                string action = tokens[0];
                if (action == "Enroll")
                {
                    string heroName = tokens[1];
                    if (heroesAndSpells.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                    else
                    {
                            heroesAndSpells.Add(heroName, new List<string>());
                    }
                }
                else if (action == "Learn")
                {
                    string heroName = tokens[1];
                    string SpellName = tokens[2];
                    if (heroesAndSpells.ContainsKey(heroName))
                    {
                        if (heroesAndSpells[heroName].Contains(SpellName))
                        {
                            Console.WriteLine($"{heroName} has already learnt {SpellName}.");
                        }
                        else
                        {
                            heroesAndSpells[heroName].Add(SpellName);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                }
                else if (action == "Unlearn")
                {
                    string HeroName = tokens[1];
                    string SpellName = tokens[2];
                    if (heroesAndSpells.ContainsKey(HeroName))
                    {
                        if (heroesAndSpells[HeroName].Contains(SpellName))
                        {
                            heroesAndSpells[HeroName].Remove(SpellName);
                        }
                        else
                        {
                            Console.WriteLine($"{HeroName} doesn't know {SpellName}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{HeroName} doesn't exist.");
                    }
                }
            }
            Console.WriteLine("Heroes:");
            foreach (var hero in heroesAndSpells)
            {
                Console.WriteLine($"== {hero.Key}: {string.Join(", ", hero.Value)}");
            }
        }
    }
}
