namespace EasterRaces.Models.Cars.Entities
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private int minHorsePower;
        private int maxHorsePower;
        private const int minSimbols = 4;
        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower= maxHorsePower;
            this.Model=model;
            this.HorsePower=horsePower;
            this.CubicCentimeters=cubicCentimeters;
        }
        public string Model
        {
            get => this.model;
            private set
            {
                if(string.IsNullOrWhiteSpace(value)||value.Length<minSimbols)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel,value,minSimbols));
                }
                this.model= value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                if(value<minHorsePower||value>maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower,value));
                }
                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get => this.cubicCentimeters; private set => this.cubicCentimeters = value; }

        public double CalculateRacePoints(int laps) => CubicCentimeters / HorsePower * laps;
       
    }
}
