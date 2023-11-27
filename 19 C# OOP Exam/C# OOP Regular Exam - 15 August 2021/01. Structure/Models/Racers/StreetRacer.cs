using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const string RacingBehavior = "aggressive";
        private const int DrivingExperience = 10;
        public StreetRacer(string username, ICar car)
            : base(username, RacingBehavior, DrivingExperience, car)
        {
        }
        public override void Race()
        {
            base.Race();
            base.DrivingExperience += 5;
        }
    }
}
