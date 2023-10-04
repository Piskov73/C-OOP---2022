namespace Formula1.Models
{
    using System;

    using Contracts;
    using Utilities;

    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private int numberOfWins;
        private bool canRace;

        public Pilot(string fullName)
        {
            FullName = fullName;
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                fullName = value;
            }
        }


        public IFormulaOneCar Car
        {
            get { return car; }
            private set { car = value; }
        }


        public int NumberOfWins
        {
            get { return numberOfWins; }
            private set { numberOfWins = value; }
        }


        public bool CanRace
        {
            get { return canRace; }
            private set { canRace = value; }
        }


        public void AddCar(IFormulaOneCar car)
        {
            this.car=car;   
            this.canRace=true;
        }

        public void WinRace()
        {
           this.numberOfWins++;
        }
        public override string ToString()
        {
            return $"Pilot {fullName } has {numberOfWins } wins.";
        }
    }
}
