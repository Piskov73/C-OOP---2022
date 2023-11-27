using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private Mission mission;
        private int exploredPlanetsCount;
        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.mission = new Mission();
            this.exploredPlanetsCount = 0;
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
                astronaut =new Geodesist(astronautName);
            }
            else if(type==nameof(Meteorologist))
            {
                astronaut=new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautType));
            }

            astronauts.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded,type,astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet=new Planet(planetName);
            foreach (string item in items)
            {
                planet.Items.Add(item);
            }
            planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded,planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut=astronauts.FindByName(astronautName);

            if(astronaut==null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut,astronautName));

            astronauts.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired,astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
           var planet=planets.FindByName(planetName);

            ICollection<IAstronaut> astronautsFilter=this.astronauts.Models.Where(x=>x.Oxygen>60).ToList();
            if (astronautsFilter.Count == 0)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautCount));
            mission.Explore(planet, astronautsFilter);
            int deedAstronaut = 0;
            foreach (var item in astronautsFilter)
            {
                if(item.Oxygen==0)
                    deedAstronaut++;
            }

            this.exploredPlanetsCount++;
            return string.Format(OutputMessages.PlanetExplored, planetName, deedAstronaut);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanetsCount} planets were explored!")
                .AppendLine($"Astronauts info:");

            foreach (var item in astronauts.Models)
            {
                string bagItems=string.Empty;
                if(item.Bag.Items.Count == 0)
                {
                    bagItems = "none";
                }
                else
                {
                    bagItems=string.Join(", ",item.Bag.Items);
                }
                sb.AppendLine($"Name: {item.Name}")
                .AppendLine($"Oxygen: {item.Oxygen}")
                .AppendLine($"Bag items: {bagItems}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
