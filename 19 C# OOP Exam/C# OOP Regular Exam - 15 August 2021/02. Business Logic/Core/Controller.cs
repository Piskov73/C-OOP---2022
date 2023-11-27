using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        //        •	cars - CarRepository 
        //•	racers – RacerRepository
        //•	map - IMap

        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;
        public Controller()
        {
            this.cars=new CarRepository();
            this.racers=new RacerRepository();
            
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;
            if (type == nameof(SuperCar))
            {
                car=new SuperCar(make,model,VIN,horsePower);
            }
            else if(type == nameof(TunedCar))
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarType));
            }

            this.cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar,make,model,VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            var car = this.cars.FindBy(carVIN);
            if (car == null)
                throw new ArgumentException(string.Format(ExceptionMessages.CarCannotBeFound));
            IRacer racer;
            if(type==nameof(ProfessionalRacer))
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if(type==nameof(StreetRacer))
            {
                racer=new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRacerType));
            }

            this.racers.Add(racer);

            return string.Format(OutputMessages.SuccessfullyAddedRacer,username);

        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racerOne=this.racers.FindBy(racerOneUsername);
            if (racerOne == null)
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound,racerOneUsername)); ;

            var racerTwo = this.racers.FindBy(racerTwoUsername);
            if (racerTwo == null)
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername)); ;
            map = new Map();

            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var racer in this.racers.Models.OrderByDescending(x=>x.DrivingExperience).ThenBy(n=>n.Username))
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
