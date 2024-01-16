using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;
        public MilitaryUnit(double cost)
        {
            this.cost=cost;
            this.enduranceLevel = 1;
        }
        public double Cost => this.cost;

        public int EnduranceLevel => this.enduranceLevel;

        public void IncreaseEndurance()
        {
            this.enduranceLevel++;
            if(this.enduranceLevel > 20)
            {
                this.enduranceLevel = 20;
                throw new ArgumentException(string.Format(ExceptionMessages.EnduranceLevelExceeded));
            }
        }
    }
}
