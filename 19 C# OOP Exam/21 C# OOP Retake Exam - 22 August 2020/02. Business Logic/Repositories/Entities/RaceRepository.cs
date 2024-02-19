using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private HashSet<IRace> models;
        public RaceRepository()
        {
            this.models = new HashSet<IRace>();
        }
        public IReadOnlyCollection<IRace> GetAll()=>models.ToList().AsReadOnly();

        public void Add(IRace model)
        {
           this.models.Add(model);
        }

      
        public IRace GetByName(string name)
        {
            return this.models.FirstOrDefault(x=> x.Name == name);
        }

        public bool Remove(IRace model)
        {
            return models.Remove(model);
        }
    }
}
