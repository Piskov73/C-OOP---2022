﻿namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const double UnitsOxigen = 90;
        public Meteorologist(string name) 
            : base(name, UnitsOxigen)
        {
        }
    }
}
