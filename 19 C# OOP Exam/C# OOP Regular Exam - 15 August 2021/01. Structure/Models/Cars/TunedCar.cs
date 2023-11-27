﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double FuelAvailable = 65;
        private const double FuelConsumptionPerRace = 75;

        public TunedCar(string make, string model, string VIN, int horsePower)
            : base(make, model, VIN, horsePower, FuelAvailable, FuelConsumptionPerRace)
        {
        }
        public override void Drive()
        {
            base.Drive();

            HorsePower = (int)Math.Ceiling(HorsePower * 0.97);
        }
    }
}
