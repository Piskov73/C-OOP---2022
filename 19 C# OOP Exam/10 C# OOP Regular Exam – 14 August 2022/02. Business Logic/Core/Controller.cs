using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            this.planets = new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {
            var planet=this.planets.FindByName(name);
            if (planet != null)
            {
                return string.Format(OutputMessages.ExistingPlanet,name);
            }

            planet = new Planet(name, budget);

            this.planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet,planetName));
            }

            var unit=planet.Army.FirstOrDefault(x=>x.GetType().Name==unitTypeName);
            if (unit != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded,unitTypeName,planetName));
            }

            if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else if(unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if(unitTypeName == nameof(AnonymousImpactUnit))
            {
                unit = new AnonymousImpactUnit();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            planet.Spend(unit.Cost);

            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded,unitTypeName,planetName );
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet,planetName));
            }

            var weapon=planet.Weapons.FirstOrDefault(x=>x.GetType().Name==weaponTypeName);

            if(weapon!=null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded,weaponTypeName,planetName));

            if(weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon=new NuclearWeapon(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            planet.Spend(weapon.Price);

            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded,planetName,weaponTypeName);
        }
        public string SpecializeForces(string planetName)
        {
            var planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet,planetName));
            }

            if(planet.Army.Count==0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound));
            }

            planet.Spend(1.25);

            foreach (var unit in planet.Army)
            {
                unit.IncreaseEndurance();
            }

            return string.Format(OutputMessages.ForcesUpgraded,planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var planetFirst = this.planets.FindByName(planetOne);
            var planetSecond = this.planets.FindByName(planetTwo);

            IPlanet winningPlanet = null;
            IPlanet losingPlanet = null;
            if (planetFirst.MilitaryPower > planetSecond.MilitaryPower)
            {
                winningPlanet = planetFirst;
                losingPlanet = planetSecond;
            }
            else if (planetFirst.MilitaryPower < planetSecond.MilitaryPower)
            {
                winningPlanet = planetSecond;
                losingPlanet = planetFirst;
            }
            else
            {
                if (planetFirst.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon))
                && !planetSecond.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
                {
                    winningPlanet = planetFirst;
                    losingPlanet = planetSecond;
                }
                else if (!planetFirst.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon))
                && planetSecond.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
                {
                    winningPlanet = planetSecond;
                    losingPlanet = planetFirst;
                }
                else
                {
                    planetFirst.Spend(planetFirst.Budget / 2);
                    planetSecond.Spend(planetFirst.Budget / 2);

                    return string.Format(OutputMessages.NoWinner);
                }
            }

            winningPlanet.Spend(winningPlanet.Budget / 2);

            double sum = losingPlanet.Budget / 2 + losingPlanet.Army.Sum(x => x.Cost) + losingPlanet.Weapons.Sum(x => x.Price);

            winningPlanet.Profit(sum);

            this.planets.RemoveItem(losingPlanet.Name);

            return string.Format(OutputMessages.WinnigTheWar, winningPlanet.Name, losingPlanet.Name);

        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in this.planets.Models.OrderByDescending(x=>x.MilitaryPower).ThenBy(x=>x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
