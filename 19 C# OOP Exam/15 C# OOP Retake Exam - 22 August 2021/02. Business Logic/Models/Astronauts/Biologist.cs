using System;
using System.Text.RegularExpressions;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double UnitsOxigen = 70;
        public Biologist(string name)
            : base(name, UnitsOxigen)
        {
        }

        public override void Breath()
        {
           this.Oxygen=Math.Max(this.Oxygen-5,0);
        }
    }
}
