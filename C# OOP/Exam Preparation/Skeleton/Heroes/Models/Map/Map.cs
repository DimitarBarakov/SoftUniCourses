using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    internal class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> barbarians = players.Where(p => p.GetType().Name == "Barbarian").ToList();
            List<IHero> knights = players.Where(p => p.GetType().Name == "Knight").ToList();
            int deathBarbarians = 0;
            int deathKnights = 0;

            while (true)
            {
                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        int points = knight.Weapon.DoDamage();
                        foreach (var barbarian in barbarians)
                        {
                            barbarian.TakeDamage(points);
                            if (!barbarian.IsAlive)
                            {
                                deathBarbarians++;
                                if (barbarians.All(b=>b.IsAlive == false))
                                {
                                    return $"The knights took {deathKnights } casualties but won the battle.";
                                }
                            }
                        }
                    }
                }
                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        int points = barbarian.Weapon.DoDamage();
                        foreach (var knight in knights)
                        {
                            knight.TakeDamage(points);
                            if (!knight.IsAlive)
                            {
                                deathKnights++;
                                if (knights.All(k=>k.IsAlive == false))
                                {
                                    return $"The barbarians took {deathBarbarians} casualties but won the battle.";
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
