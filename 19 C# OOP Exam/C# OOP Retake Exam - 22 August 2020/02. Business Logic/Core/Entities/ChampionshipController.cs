using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;

using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private const int MinDriversAndRace = 3;
        private CarRepository cars;
        private DriverRepository drivers;
        private RaceRepository races;
        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }
        public string CreateDriver(string driverName)
        {
            var driver = drivers.GetByName(driverName);
            if (driver != null)
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists,driverName));

            driver = new Driver(driverName);
            drivers.Add(driver);

            return string.Format(OutputMessages.DriverCreated,driverName);
        }
        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car;
            if (type == "Muscle")
            {
                car=new MuscleCar(model, horsePower);
            }
            else if(type == "Sports")
            {
                car=new SportsCar(model, horsePower);
            }
            else
            {
                return null;
            }

            if (this.cars.GetAll().Any(x=>x.GetType()==car.GetType()&&x.Model==car.Model&&x.HorsePower==car.HorsePower))
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists,model));

            this.cars.Add(car);
            return string.Format(OutputMessages.CarCreated,car.GetType().Name,model);
        }

        public string CreateRace(string name, int laps)
        {
           var race=this.races.GetByName(name);

            if(race != null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists,name));
            race=new Race(name, laps);
            this.races.Add(race);
            return string.Format(OutputMessages.RaceCreated,name);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
           var driver=this.drivers.GetByName(driverName);

            if(driver==null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound,driverName));

            var car=this.cars.GetByName(carModel);

            if(car==null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));

            driver.AddCar(car);

            this.cars.Remove(car);

            return string.Format(OutputMessages.CarAdded,driverName,carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = this.races.GetByName(raceName);

            if(race==null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));

            var driver =this.drivers.GetByName(driverName);
            if(driver==null)
            throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));

            race.AddDriver(driver);


            return string.Format(OutputMessages.DriverAdded,driverName,raceName);
        }


        public string StartRace(string raceName)
        {
            
            var race = this.races.GetByName(raceName);

            if (race == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));

            if(race.Drivers.Count < MinDriversAndRace)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName,MinDriversAndRace));

            

            var ranking = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).ToList();

            this.races.Remove(race);

            ranking[0].WinRace();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Driver {ranking[0].Name} wins {raceName} race.")
                .AppendLine($"Driver {ranking[1].Name} is second in {raceName} race.")
                .AppendLine($"Driver {ranking[2].Name} is third in {raceName} race.");

            return sb.ToString().TrimEnd();
        }
    }
}
