using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int MinSimbolsName = 5;
        private string name;
        private ICar car;
        private int numberOfWins;
        private bool canParticipate;
        public Driver(string name)
        {
            Name = name;
            this.car = null;
           this. canParticipate = false;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinSimbolsName)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MinSimbolsName));

                name = value;
            }
        }
        public ICar Car { get => car; }

        public int NumberOfWins { get => numberOfWins; }

        public bool CanParticipate { get => canParticipate; }

        public void AddCar(ICar car)
        {
            if (car == null)
                throw new ArgumentNullException(string.Format(ExceptionMessages.CarInvalid));

            this.car = car;
            this.canParticipate = true;
        }

        public void WinRace()
        {
            this.numberOfWins++;
        }
    }
}
