using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int MinSimbol = 4;
        private string model;
        private double cubicCentimeters;
        private int horsePower;
        private int minHorsePower;
        private int maxHorsePower;
        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            Model = model;
            HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
         
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinSimbol)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, MinSimbol));

                model = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;
            private set
            {
                if (value <this. minHorsePower || value >this. maxHorsePower)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));

                value = horsePower;
            }
        }

        public double CubicCentimeters { get => cubicCentimeters; private set => value = cubicCentimeters; }

        public double CalculateRacePoints(int laps)
        {
            return laps * CubicCentimeters * HorsePower;
        }
    }
}
