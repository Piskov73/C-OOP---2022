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
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.CharacterNameInvalid));
                name = value;
            }
        }


        public double BaseHealth
        {
            get { return baseHealth; }
            private set { baseHealth = value; }
        }


        public double Health
        {
            get { return health; }
            set
            {
                if (value < 0)
                    value = 0;
                if(value>BaseHealth) value = BaseHealth;
                health = value;
            }
        }

        public double BaseArmor { get => baseArmor; private set => baseArmor = value; }

        public double Armor
        {
            get => armor;
            set
            {
                if (value < 0)
                    value = 0;

                armor = value;
            }
        }

        public double 	AbilityPoints{ get=>abilityPoints;private set=>abilityPoints=value; }

        public Bag Bag { get=>bag; private set=>bag=value; }
        public bool IsAlive { get => Health > 0; }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            double armorDamage=Math.Min(Armor, hitPoints);
            Armor -= armorDamage;
            double healthDamage=Math.Min(Health, hitPoints-armorDamage);
            Health-= healthDamage;
        }
        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }
    }
}