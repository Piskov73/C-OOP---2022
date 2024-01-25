using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private readonly PilotRepository pilotRepository;
        private readonly RaceRepository raceRepository;
        private readonly FormulaOneCarRepository carRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }
        public string CreatePilot(string fullName)
        {
            var pilot = this.pilotRepository.FindByName(fullName);
            if (pilot != null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));

            pilot = new Pilot(fullName);

            this.pilotRepository.Add(pilot);

            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }
        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            var car = this.carRepository.FindByName(model);

            if (car != null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));

            if (type == nameof(Ferrari))
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == nameof(Williams))
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            this.carRepository.Add(car);

            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }
        public string CreateRace(string raceName, int numberOfLaps)
        {
            var race = this.raceRepository.FindByName(raceName);

            if (race != null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));

            race = new Race(raceName, numberOfLaps);

            this.raceRepository.Add(race);

            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = this.pilotRepository.FindByName(pilotName);

            if (pilot == null || pilot.CanRace)
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));

            var car = this.carRepository.FindByName(carModel);

            if (car == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));

            pilot.AddCar(car);

            this.carRepository.Remove(car);

            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = this.raceRepository.FindByName(raceName);

            if (race == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));

            var pilot = this.pilotRepository.FindByName(pilotFullName);

            if (pilot == null || pilot.CanRace == false || race.Pilots.Any(x => x.FullName == pilotFullName))
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));

            race.AddPilot(pilot);

            return string.Format(OutputMessages.SuccessfullyAddPilotToRace,pilotFullName,raceName);
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.FindByName(raceName);

            if (race == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));

            if(race.Pilots.Count<3)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants,raceName));

            if(race.TookPlace)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));

            race.TookPlace = true;
            var pilotsFinal=race.Pilots.OrderByDescending(x=>x.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3).ToList();
            pilotsFinal[0].WinRace();


            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.PilotFirstPlace, pilotsFinal[0].FullName,raceName))
                 .AppendLine(string.Format(OutputMessages.PilotSecondPlace, pilotsFinal[1].FullName, raceName))
                 .AppendLine(string.Format(OutputMessages.PilotThirdPlace, pilotsFinal[2].FullName, raceName));

            return sb.ToString().TrimEnd();

        }
        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var race in this.raceRepository.Models)
            {
                if(race.TookPlace)
                sb.AppendLine(race.RaceInfo());

            }
                

            return sb.ToString().TrimEnd();
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var pilot in this.pilotRepository.Models.OrderByDescending(x=>x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());

            }


            return sb.ToString().TrimEnd();
        }


    }
}
