using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private IMission mission;
        private int exploredPlanetsCount;
        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.mission = new Mission();
            exploredPlanetsCount = 0;
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautType));
            }

            this.astronauts.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }
        public string RetireAstronaut(string astronautName)
        {
            var astr = this.astronauts.FindByName(astronautName);
            if (astr == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronauts.Remove(astr);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = this.planets.FindByName(planetName);

            List<IAstronaut> astronauts = this.astronauts.Models.Where(x => x.Oxygen > 60).ToList();

            if(astronauts.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautCount));
            }

            this.mission.Explore(planet, astronauts);

            int countDeadAstronauts = 0;

            foreach (var astr in astronauts)
            {
                if (!astr.CanBreath)
                    countDeadAstronauts++;
            }
            exploredPlanetsCount++;
            return string.Format(OutputMessages.PlanetExplored, planetName, countDeadAstronauts);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanetsCount} planets were explored!")
                .AppendLine("Astronauts info:");

            foreach (var astronaut in this.astronauts.Models)
            {
                string bagItems = "none";
                if(astronaut.Bag.Items.Count > 0)
                {
                    bagItems=string.Join(", ",astronaut.Bag.Items);
                }
                sb.AppendLine($"Name: {astronaut.Name}")
                    .AppendLine($"Oxygen: {astronaut.Oxygen}")
                    .AppendLine($"Bag items: {bagItems}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
