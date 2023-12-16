using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private HashSet<IRace> races;
        private RaceRepository()
        { 

        }
        public void Add(IRace model)
        {
            this.races.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()=>this.races.ToList<IRace>().AsReadOnly();
       

        public IRace GetByName(string name)
        {
           return this.races.FirstOrDefault(races => races.Name == name);
        }

        public bool Remove(IRace model)
        {
      return races.Remove(model);
        }
    }
}
