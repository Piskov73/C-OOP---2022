using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Xml.Linq;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository drivers;
        private CarRepository cars;
        private RaceRepository races;
        public ChampionshipController()
        {
            this.drivers = new DriverRepository();
            this.cars = new CarRepository();
            this.races = new RaceRepository();
        }
        public string CreateDriver(string driverName)
        {
            IDriver driver = this.drivers.GetByName(driverName);
            if (driver != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            driver = new Driver(driverName);

            this.drivers.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }
        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = this.cars.GetByName(model);

            if (car != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists,model));
            }

            if(type== "Muscle")
            {
                car=new MuscleCar(model,horsePower);
            }
            else if(type== "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            else
            {
                throw new ArgumentException();
            }
            this.cars.Add(car);

            return string.Format(OutputMessages.CarCreated,car.GetType().Name,model);
        }
        public string CreateRace(string name, int laps)
        {
            IRace race=this.races.GetByName(name);

            if(race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists,name));
            }
            race=new Race(name, laps);

            this.races.Add(race);

            return string.Format(OutputMessages.RaceCreated,name);
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver=this.drivers.GetByName(driverName);
            if(driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound,driverName));
            }

            ICar car = this.cars.GetByName(carModel);

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded,driverName,carModel);
        }
        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race=this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound,raceName));
            }

            IDriver driver = this.drivers.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded,driverName,raceName);
        }
        public string StartRace(string raceName)
        {
            IRace race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if(race.Drivers.Count <3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName,3));
            }

            List<IDriver > driversRace=race.Drivers.OrderByDescending(x=>x.Car.CalculateRacePoints(race.Laps)). ToList();

            this.races.Remove(race);

            driversRace[0].WinRace();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, driversRace[0].Name,raceName))
                .AppendLine(string.Format(OutputMessages.DriverSecondPosition, driversRace[1].Name, raceName))
                .AppendLine(string.Format(OutputMessages.DriverThirdPosition, driversRace[2].Name, raceName));

            return sb.ToString().TrimEnd();
        }
    }
}
