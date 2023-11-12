using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;
        public PlanetRepository() 
        { 

        }
        public IReadOnlyCollection<IPlanet> Models => this.planets.AsReadOnly();

        public void AddItem(IPlanet model)
        {
            this.planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
           return this.planets.FirstOrDefault(x=> x.Name == name);
        }

        public bool RemoveItem(string name)
        {
            return this.planets.Remove(FindByName(name));
        }
    }
}
