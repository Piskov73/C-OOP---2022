using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;

        protected Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.WeaponTypeNull));
                }
                name = value;
            }
        }

        public virtual int Durability
        {
            get { return durability; }
            private set
            {
                if(value< 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.DurabilityBelowZero));
                }
                durability = value;
            }
        }



        public virtual int DoDamage()
        {
            Durability--;
            return 0;
        }
       
    }
}
