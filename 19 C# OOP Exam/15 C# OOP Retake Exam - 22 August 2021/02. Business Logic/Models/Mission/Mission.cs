using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astr in astronauts)
            {
                while (astr.CanBreath==true&&planet.Items.Count>0)
                {
                    string item = planet.Items.FirstOrDefault();
                    astr.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                    astr.Breath();
                }
                if (planet.Items.Count==0)
                {
                    break;
                }
            }
        }
    }
}
