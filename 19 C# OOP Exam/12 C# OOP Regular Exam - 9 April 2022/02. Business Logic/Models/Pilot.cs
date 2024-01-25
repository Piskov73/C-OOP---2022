using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private int numberOfWins;
        private bool canRace;
        public Pilot(string fullName)
        {
            this.FullName=fullName;
            this.numberOfWins = 0;
            this.canRace=false;
        }
        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));

                this.fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get => this.car;
            private set
            {
                if (value == null)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCarForPilot));

                this.car = value;
            }
        }

        public int NumberOfWins { get => this.numberOfWins; private set => numberOfWins = value; }

        public bool CanRace { get => canRace; private set => canRace = value; }

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.canRace = true;
        }

        public void WinRace()
        {
           this.numberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {FullName } has {NumberOfWins } wins.";
        }
    }
}
