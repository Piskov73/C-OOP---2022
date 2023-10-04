namespace Formula1.Core
{
    using Contracts;
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Formula1.Repositories;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.ConstrainedExecution;
    using System.Text;

    public class Controller : IController
    {
    
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public object EceptionMessage { get; private set; }

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository= new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            var pilot=this.pilotRepository.FindByName(fullName);
            if (pilot != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage,fullName));
            }
            pilot = new Pilot(fullName);
            this.pilotRepository.Add(pilot);
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            var car=this.carRepository.FindByName(type);
            if (car!=null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            if (type != "Ferrari" && type != "Williams")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            if (type == "Ferrari")
            {
                car=new Ferrari(model, horsepower, engineDisplacement);
            }
            else if(type == "Williams")
            {

                car = new Williams(model, horsepower, engineDisplacement);
            }

            this.carRepository.Add(car);

            return string.Format(OutputMessages.SuccessfullyCreateCar,type,model);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            var race=this.raceRepository.FindByName(raceName);

            if(race!=null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            race=new Race(raceName, numberOfLaps);

            this.raceRepository.Add(race);

            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = this.pilotRepository.FindByName(pilotName);
            if(pilot==null||pilot.CanRace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage,pilotName));
            }
            var car=this.carRepository.FindByName(carModel);
            if(car==null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            pilot.AddCar(car);
            this.carRepository.Remove(car);

            return string.Format(OutputMessages.SuccessfullyPilotToCar,pilotName , car.GetType().Name,carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race=this.raceRepository.FindByName(raceName);
            if(race==null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            var pilot = this.pilotRepository.FindByName(pilotFullName);

            if (pilot == null||!pilot.CanRace|| race.Pilots.Any(p=>p.FullName==pilotFullName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage,pilotFullName));
            }

            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace,pilotFullName,raceName);
        }

        public string StartRace(string raceName)
        {
           
            var race=raceRepository.FindByName(raceName);
            if(race==null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage,raceName));
            }
            if (race.Pilots.Count < 3)
            {
                     throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            race.TookPlace = true;
            int laps = race.NumberOfLaps;
            List<IPilot> pilots= race.Pilots.OrderByDescending(p=>p.Car.RaceScoreCalculator(laps)).ToList();

            pilots[0].WinRace();

            StringBuilder sb= new StringBuilder();

            sb.AppendLine($"Pilot {pilots[0].FullName} wins the {raceName} race.")
                .AppendLine($"Pilot {pilots[1].FullName} is second in the {raceName} race.")
                .AppendLine($"Pilot {pilots[2].FullName} is third in the {raceName} race.");

            return sb.ToString().Trim();
        
        }
        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var race in this.raceRepository.Models)
            {
                if (race.TookPlace)
                {
                    sb.AppendLine(race.RaceInfo());
                }
            }

            return sb.ToString().Trim();
        }
        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var pilot in this.pilotRepository.Models.OrderByDescending(p=>p.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().Trim();
        }

      

      
    }
}
