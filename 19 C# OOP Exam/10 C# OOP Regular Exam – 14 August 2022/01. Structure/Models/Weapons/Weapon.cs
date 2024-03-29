﻿using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private int destructionLevel;
        private double price;
        public Weapon(int destructionLevel, double price) 
        {
            this.DestructionLevel = destructionLevel;
            this.price = price;
        }
        public double Price => price;

        public int DestructionLevel
        {
            get => destructionLevel;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.TooLowDestructionLevel));
                }
                else if (value > 10)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.TooHighDestructionLevel));
                }
                destructionLevel=value;
            }
        }
    }
}
