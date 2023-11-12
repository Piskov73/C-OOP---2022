using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
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
        private UnitRepository  army;
        private WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            this.army = new UnitRepository();
            this.weapons = new WeaponRepository();


        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPlanetName));
                }
                name = value;
            }
        }


        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidBudgetAmount));
                }
                budget = value;
            }
        }



        public double MilitaryPower => Math.Round(Calculator(), 3);

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

        public string PlanetInfo()
        {
            string military = string.Empty;
            if(Army.Count==0)
            {
                military = "No units";
            }
            else
            {
                List<string> unitName = new List<string>();
                foreach (var item in Army)
                {
                    unitName.Add(item.GetType().Name);
                }
                military = string.Join(", ", unitName);
            }
            string weapon = string.Empty;
            if (Weapons.Count == 0)
            {
                weapon = "No weapons";
            }
            else
            {
                List<string> wearponName = new List<string>();
                foreach (var item in Weapons)
                {
                    wearponName.Add(item.GetType().Name);
                }
                military = string.Join(", ", wearponName);
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}")
                .AppendLine($"--Budget: {Budget} billion QUID")
                .AppendLine($"--Forces: {military}")
                .AppendLine($"--Combat equipment: {weapon}")
                .AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            this.budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount > this.budget)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnsufficientBudget));
            }
            this.budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var arm in this.army.Models)
            {
                arm.IncreaseEndurance();
            }
        }
        private double Calculator()
        {
            double sum = this.army.Models.Sum(x => x.EnduranceLevel) + this.weapons.Models.Sum(x => x.DestructionLevel);
            if (this.army.Models.Any(x => x.GetType().Name == "AnonymousImpactUnit "))
            {
                sum *= 1.3;
            }
            if (this.weapons.Models.Any(x => x.GetType().Name == "NuclearWeapon "))
            {
                sum *= 1.45;
            }

            return sum;

        }
    }
}
