using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.
        private string name;
        public Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armor;
            this.AbillityPoints = abilityPoints;
            this.Bag = bag;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }
        public double BaseHealth { get; set; }
        public double Health { get; set; }
        public double BaseArmour { get; set; }
        public double Armour { get; set; }
        public double AbillityPoints { get; set; }
        public IBag Bag { get; set; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
        public void TakeDamage(double hitPoints)
        {
            if (IsAlive)
            {
                if (hitPoints > this.Armour)
                {
                    hitPoints -= this.Armour;
                    if (hitPoints >= this.Health)
                    {
                        this.Health = 0;
                        this.IsAlive = false;
                    }
                    else
                    {
                        this.Health -= hitPoints;
                    }
                }
                else
                {
                    this.Armour -= hitPoints;
                }
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }
    }
}