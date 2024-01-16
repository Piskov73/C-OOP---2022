using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;
        public PlanetRepository()
        {

        }
        public IReadOnlyCollection<IPlanet> Models => throw new System.NotImplementedException();

        public void AddItem(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.models.FirstOrDefault(n=>n.Name == name);
        }

        public bool RemoveItem(string name)
        {
            return  this.models.Remove(FindByName(name));
        }
    }
}
