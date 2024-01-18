using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private UnitRepository army;
        private WeaponRepository weapons;
        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.army = new UnitRepository();
            this.weapons = new WeaponRepository();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPlanetName));
                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidBudgetAmount));
                budget = value;
            }
        }

        public double MilitaryPower => TotalAmount();

        public IReadOnlyCollection<IMilitaryUnit> Army => this.army.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.army.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }
        public void TrainArmy()
        {
            foreach (var unit in this.army.Models)
            {
                unit.IncreaseEndurance();
            }
        }
        public void Spend(double amount)
        {
            if (amount > this.budget)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnsufficientBudget));
            }
            this.budget-=amount;
        }
        public void Profit(double amount)
        {
            this.budget += amount;
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string militaryUnitName = "No units";
            if(Army.Count> 0)
            {
                List<string > militaryUnitNames= new List<string>();
                foreach (var item in Army)
                {
                    militaryUnitNames.Add(item.GetType().Name);
                }
                militaryUnitName=string.Join(", ", militaryUnitNames);
            }
            string weaponName = "No weapons";
            if (Weapons.Count > 0)
            {
                List<string> weaponNames = new List<string>();
                foreach (var weapon in Weapons)
                {
                    weaponNames.Add(weapon.GetType().Name);
                }
                weaponName=string.Join(", ",weaponNames);
            }
            sb.AppendLine($"Planet: {Name}")
                .AppendLine($"--Budget: {Budget} billion QUID")
                .AppendLine($"--Forces: {militaryUnitName}")
                .AppendLine($"--Combat equipment: {weaponName}")
                .AppendLine($"--Military Power: {MilitaryPower}");
               

            return sb.ToString().TrimEnd();
        }



        private double TotalAmount()
        {
            double sum = 0;
            sum = Army.Sum(x => x.EnduranceLevel) + Weapons.Sum(x=>x.DestructionLevel);
            if (Army.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                sum *= 1.3;
            }
            if (Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                sum *= 1.45;
            }

            return Math.Round(sum,3);
        }
    }
}
