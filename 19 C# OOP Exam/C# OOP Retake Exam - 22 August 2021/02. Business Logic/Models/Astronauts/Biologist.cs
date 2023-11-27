using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double OXYGEN = 70;
        public Biologist(string name)
            : base(name, OXYGEN)
        {
        }
        public override void Breath()
        {
            Oxygen = Math.Max(Oxygen - 5, 0);
        }
    }
}
