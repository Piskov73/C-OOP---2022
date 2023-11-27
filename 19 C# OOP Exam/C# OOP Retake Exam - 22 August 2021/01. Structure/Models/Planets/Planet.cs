﻿using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private List<string> items;
        public Planet(string name)
        {
            Name = name;
            this.items = new List<string>();
        }
        public ICollection<string> Items => this.items.AsReadOnly();


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidPlanetName));
                name = value;
            }
        }

    }
}
