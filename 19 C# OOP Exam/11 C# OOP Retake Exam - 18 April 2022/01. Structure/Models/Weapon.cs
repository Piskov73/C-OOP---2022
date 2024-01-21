using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;

namespace Heroes.Models
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;
        public Weapon(string name, int durability) 
        {
            this.Name=name;
            this.Durability=durability;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.WeaponTypeNull));

                name = value;
            }
        }

        public int Durability 
        {
            get => durability;
            protected set
            {
                if(value<0)
                    throw new ArgumentException(string.Format(ExceptionMessages.WeaponTypeNull));

                durability = value;
            }
        }

        public abstract int DoDamage();
       
    }
}
