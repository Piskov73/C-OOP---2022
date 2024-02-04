using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;
        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.bag = new Backpack();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidAstronautName));
                this.name = value;
            }
        }
        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidOxygen));
                this.oxygen = value;
            }
        }

        public bool CanBreath => this.oxygen > 0;

        public IBag Bag =>this.bag;

        public virtual void Breath()
        {
            this.Oxygen = Math.Max(this.Oxygen - 10, 0);
        }
    }
}
