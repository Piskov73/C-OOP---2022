using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    internal class DriverRepository : IRepository<IDriver>
    {
        private HashSet<IDriver> drivers;

        public DriverRepository()
        {
            this.drivers = new HashSet<IDriver>();
        }

        public void Add(IDriver model)
        {
            this.drivers.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()=>this.drivers.ToList<IDriver>().AsReadOnly();
      

        public IDriver GetByName(string name)
        {
            return this.drivers.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IDriver model)
        {
            return drivers.Remove(model);
        }
    }
}
