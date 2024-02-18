using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private HashSet<ICar> cars;
        public CarRepository()
        {
            this.cars=new HashSet<ICar>();
        }
        public IReadOnlyCollection<ICar> GetAll()=>this.cars.ToList().AsReadOnly();
       
        public void Add(ICar model)
        {
           this.cars.Add(model);
        }


        public ICar GetByName(string name)
        {
            return this.cars.FirstOrDefault(c => c.Model == name);
        }

        public bool Remove(ICar model)
        {
            return this.cars.Remove(model);
        }
    }
}
