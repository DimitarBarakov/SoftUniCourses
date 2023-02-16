using System;
using System.Collections.Generic;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] heroAtributes = Console.ReadLine().Split(" ");
                string name = heroAtributes[0];
                int hp = int.Parse(heroAtributes[1]);
                int mp = int.Parse(heroAtributes[2]);

                heroes.Add(name, new List<int> { hp, mp });
            }

            string comand;
            while ((comand = Console.ReadLine()) != "End")
            {
                string[] tokens = comand.Split(" - ");
                string action = tokens[0];
                if (action == "CastSpell")
                {
                    string name = tokens[1];
                    int mpNeeded = int.Parse(tokens[2]);
                    string spell = tokens[3];
                    if (heroes[name][1] >= mpNeeded)
                    {
                        heroes[name][1] -= mpNeeded;
                        Console.WriteLine($"{name} has successfully cast {spell} and now has {heroes[name][1]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} does not have enough MP to cast {spell}!");
                    }
                }
                else if (action == "TakeDamage")
                {
                    string name = tokens[1];
                    int damage = int.Parse(tokens[2]);
                    string attacker = tokens[3];
                    if (heroes[name][0] - damage > 0)
                    {
                        heroes[name][0] -= damage;
                        Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name][0]} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                        heroes.Remove(name);
                    }
                }
                else if (action == "Recharge")
                {
                    string name = tokens[1];
                    int amount = int.Parse(tokens[2]);
                    if (heroes[name][1] + amount > 200)
                    {
                        amount = 200 - heroes[name][1];
                        heroes[name][1] = 200;
                        Console.WriteLine($"{name} recharged for {amount} MP!");
                    }
                    else
                    {
                        heroes[name][1] += amount;
                        Console.WriteLine($"{name} recharged for {amount} MP!");
                    }
                }
                else if (action == "Heal")
                {
                    string name = tokens[1];
                    int amount = int.Parse(tokens[2]);
                    if (heroes[name][0] + amount > 100)
                    {
                        amount = 100 - heroes[name][0];
                        heroes[name][0] = 100;
                        Console.WriteLine($"{name} healed for {amount} HP!");
                    }
                    else
                    {
                        heroes[name][0] += amount;
                        Console.WriteLine($"{name} healed for {amount} HP!");
                    }
                }
            }
            foreach (var hero in heroes)
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value[0]}");
                Console.WriteLine($"  MP: {hero.Value[1]}");
            }
        }
    }
}
