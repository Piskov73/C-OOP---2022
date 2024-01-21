using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;

namespace Heroes.Models
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;
        public Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour= armour;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.HeroNameNull));

                name = value;
            }
        }

        public int Health
        {
            get => health;
            private set
            {
                if(value<0)
                    throw new ArgumentException(string.Format(ExceptionMessages.HeroHealthBelowZero));

                health = value;
            }
        }

        public int Armour
        {
            get => armour;
            private set
            {
                if(value<0)
                    throw new ArgumentException(string.Format(ExceptionMessages.HeroArmourBelowZero));

                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => weapon;
            private set
            {
                if(value==null)
                    throw new ArgumentException(string.Format(ExceptionMessages.WeaponNull));

                weapon = value;
            }
        }

        public bool IsAlive => this.health > 0;

        public void AddWeapon(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            if (this.armour > points)
            {
                this.armour -= points;
            }
            else
            {
                points -= this.armour; this.armour = 0;
                if (this.health > points)
                {
                    this.health -= points;
                }
                else
                {
                    this.health = 0;
                }
            }
        }
    }
}
