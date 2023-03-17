using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;
        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IWeapon weapon = weapons.Models.FirstOrDefault(h => h.Name == weaponName);
            Hero hero = (Hero)heroes.Models.FirstOrDefault(m => m.Name == heroName);
            if (hero == null)
            {
                throw new InvalidOperationException($"The hero { heroName } does not exists.");
            }
            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon { weaponName } does not exist.");
            }
            if (heroes.Models.First(m=>m.Name == heroName).Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }
            hero.AddWeapon(weapon);
            weapons.Remove(weapon);
            return $"Hero {heroName} can participate in battle using a { weapon.GetType().Name.ToLower() }.";

        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.Models.Any(h => h.Name == name))
            {
                throw new InvalidOperationException($"The hero { name } already exists.");
            }
            if (type != "Barbarian" && type != "Knight")
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
            if (type == "Barbarian")
            {
                Barbarian bar = new Barbarian(name, health, armour);
                heroes.Add(bar);
                return $"Successfully added Barbarian { name } to the collection.";
            }
            Knight knight = new Knight(name, health, armour);
            heroes.Add(knight);
            return $"Successfully added Sir { name } to the collection.";
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.Models.Any(h => h.Name == name))
            {
                throw new InvalidOperationException($"The weapon { name } already exists.");
            }
            if (type.ToLower() != "mace" && type.ToLower() != "claymore")
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }
            if (type.ToLower() == "mace")
            {
                Mace mace = new Mace(name, durability);
                weapons.Add(mace);
                return $"A { type.ToLower() } {  name } is added to the collection.";
            }
            Claymore claymore = new Claymore(name, durability);
            weapons.Add(claymore);
            return $"A {  type.ToLower() } { name } is added to the collection.";
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            var sorted = heroes.Models
                .OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name);
            foreach (var hero in sorted)
            {
                sb.AppendLine($"{ hero.GetType().Name }: { hero.Name }");
                sb.AppendLine($"--Health: { hero.Health }");
                sb.AppendLine($"--Armour: { hero.Armour }");
                sb.AppendLine($"--Weapon: { (hero.Weapon == null?"Unarmed" : hero.Weapon.Name)}");
            }
            return sb.ToString().Trim();
        }

        public string StartBattle()
        {
            IMap map = new Map();
            IHero[] players = heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToArray(); 
            return map.Fight(players);
        }
    }
}
