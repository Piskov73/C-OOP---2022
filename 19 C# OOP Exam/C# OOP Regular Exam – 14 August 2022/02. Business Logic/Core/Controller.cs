using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Weapons;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        //•	planets - PlanetRepository
        private PlanetRepository planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet,planetName));
            }
            var unit = planet.Army.FirstOrDefault(x => x.GetType().Name == unitTypeName);
            if (unit != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }
            if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet));
            }
            var weapont = planet.Weapons.FirstOrDefault(x => x.GetType().Name == weaponTypeName);
            if (weapont != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }
            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapont = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapont = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapont = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            planet.Spend(weapont.Price);
            planet.AddWeapon(weapont);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }
        public string SpecializeForces(string planetName)
        {
            var planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound));
            }
            planet.Spend(1.25);
            planet.TrainArmy();
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string CreatePlanet(string name, double budget)
        {
            var planet = this.planets.FindByName(name);
            if (planet != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }
            planet = new Planet(name, budget);

            this.planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);
        }
        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var firstPlanet=this.planets.FindByName(planetOne);
            var secondPlanet = this.planets.FindByName(planetTwo);

            string output=string.Empty;

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                if (firstPlanet.Army.Any(x => x.GetType().Name == nameof(NuclearWeapon))
                    && secondPlanet.Army.Any(x => x.GetType().Name != nameof(NuclearWeapon)))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    firstPlanet.Profit(secondPlanet.Budget / 2);

                    firstPlanet.Profit(secondPlanet.Army.Sum(x => x.Cost));
                    firstPlanet.Profit(secondPlanet.Weapons.Sum(x=>x.Price));

                    this.planets.RemoveItem(planetTwo);
                    output= output = string.Format(OutputMessages.WinnigTheWar,planetOne,planetTwo);

                }
                else if(secondPlanet.Army.Any(x => x.GetType().Name == nameof(NuclearWeapon))
                    && firstPlanet.Army.Any(x => x.GetType().Name != nameof(NuclearWeapon)))
                {
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    secondPlanet.Profit(firstPlanet.Budget / 2);

                    secondPlanet.Profit(firstPlanet.Army.Sum(x=>x.Cost));
                    secondPlanet.Profit(firstPlanet.Weapons.Sum(x => x.Price));

                    this.planets.RemoveItem(planetOne);
                    output = output = string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
                else
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);

                    output = string.Format(OutputMessages.NoWinner);
                }
            }
            else if(firstPlanet.MilitaryPower>secondPlanet.MilitaryPower)
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Budget / 2);

                firstPlanet.Profit(secondPlanet.Army.Sum(x => x.Cost));
                firstPlanet.Profit(secondPlanet.Weapons.Sum(x => x.Price));

                this.planets.RemoveItem(planetTwo);
                output = output = string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else
            {
                secondPlanet.Spend(secondPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Budget / 2);

                secondPlanet.Profit(firstPlanet.Army.Sum(x => x.Cost));
                secondPlanet.Profit(firstPlanet.Weapons.Sum(x => x.Price));

                this.planets.RemoveItem(planetOne);
                output = output = string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }
            return output;
        }

        public string ForcesReport()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in this.planets.Models.OrderByDescending(x=>x.MilitaryPower).ThenBy(x=>x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().TrimEnd();   
        }


    }
}
