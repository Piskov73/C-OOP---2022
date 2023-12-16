using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int MinSimbilsName = 5;
        private const int MinLaps = 1;
        private string name;
        private int laps;
        private List<IDriver> drivers;
        public Race(string name,int laps)
        {
            Name = name;
            this.drivers=new List<IDriver>();   
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinSimbilsName)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MinSimbilsName));

                name = value;
            }
        }

        public int Laps
        {
            get => laps;
            private set
            {
                if(value<MinLaps)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps,MinLaps));
                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers.AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverInvalid));

            if(!driver.CanParticipate)
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));

            if(this.drivers.Contains(driver))
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded,driver.Name,Name));

            this.drivers.Add(driver);
        }
    }
}
