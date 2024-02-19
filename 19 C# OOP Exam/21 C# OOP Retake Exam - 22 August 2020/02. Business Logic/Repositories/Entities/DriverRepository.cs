using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private HashSet<IDriver> models;
        public DriverRepository()
        {
            this.models=new HashSet<IDriver>();
        }
        public IReadOnlyCollection<IDriver> GetAll()=>this.models.ToList().AsReadOnly();
       
        public void Add(IDriver model)
        {
            this.models.Add(model);

        }


        public IDriver GetByName(string name)
        {
           return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IDriver model)
        {
           return this.models.Remove(model);
        }
    }
}
