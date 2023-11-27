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
            foreach (var ast in astronauts)
            {
                while (ast.CanBreath&&planet.Items.Count>0)
                {
                    ast.Breath();
                    var temp = planet.Items.First();
                    ast.Bag.Items.Add(temp);
                    planet.Items.Remove(temp);
                }

                if (planet.Items.Count == 0) break;
            }
        }
    }
}
