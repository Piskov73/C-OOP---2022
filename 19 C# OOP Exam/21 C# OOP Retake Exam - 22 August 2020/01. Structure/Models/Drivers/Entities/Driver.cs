using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int MIN_NAME_SIMBOLS = 5;
        private string name;
        private ICar car;
        private int numberOfWins;

        public Driver(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length == MIN_NAME_SIMBOLS)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName,value,MIN_NAME_SIMBOLS));
                }
                this.name = value;
            }

        }

        public ICar Car
        {
            get=>this.car;
            private set
            {
                if(value == null)
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.CarInvalid));
                }
                this.car = value;
            }
        }

        public int NumberOfWins => this.numberOfWins;

        public bool CanParticipate => this.Car!=null;

        public void AddCar(ICar car)
        {
          this.Car = car;
        }

        public void WinRace()
        {
            this.numberOfWins++;
        }
    }
}
