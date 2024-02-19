using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int MIN_NAME_SIMBOLS = 5;
        private const int MIN_NUMBER_LAPS = 1;
        private string name;
        private int laps;
        private HashSet<IDriver> drivers;
        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new HashSet<IDriver>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrEmpty(value)||value.Length<MIN_NAME_SIMBOLS)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName,value,MIN_NAME_SIMBOLS));
                }
                this.name = value;
            }
        }

        public int Laps
        {
            get=>this.laps;
            private set
            {
                if(value<MIN_NUMBER_LAPS)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps,MIN_NUMBER_LAPS));
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers.ToList().AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverInvalid));
            }
            else if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate,driver.Name));
            }
            else if (this.drivers.Contains(driver))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded,driver.Name,Name));
            }

            this.drivers.Add(driver);
        }
    }
}
