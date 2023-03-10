using Raiding.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private ICollection<BaseHero> heroGroup;

        public Engine()
        {
            this.heroGroup = new List<BaseHero>();
        }

        public ICollection<BaseHero> HeroGroup
        {
            get { return heroGroup; }
            set { heroGroup = value; }
        }

        public void Start()
        {
            int n = int.Parse(Console.ReadLine());
            while(this.HeroGroup.Count < n)
            { 
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                try
                {
                    HeroFactory heroFactory = new HeroFactory();
                    BaseHero hero = heroFactory.CreateHero(type, name);
                    this.HeroGroup.Add(hero);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid hero!");
                }
            }
            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in this.HeroGroup)
            {
                Console.WriteLine(hero.CastAbility());
            }

            if (CalculateHeroesPower(this.HeroGroup) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        public int CalculateHeroesPower(ICollection<BaseHero> heroes)
        {
            int heroesPower = heroes.Sum(h => h.Power);
            return heroesPower;
        }
    }
}
