using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private List <IRoute> routes;

        public RouteRepository()
        {
            this.routes = new List<IRoute>();
        }
        public IReadOnlyCollection<IRoute> GetAll() => this.routes.AsReadOnly();
        
        public void AddModel(IRoute model)
        {
            this.routes.Add(model);
        }

        public IRoute FindById(string identifier)
        {
            return this.routes.FirstOrDefault(x=>x.RouteId==int.Parse(identifier));
        }

      

        public bool RemoveById(string identifier)
        {
            return this.routes.Remove(FindById(identifier));
        }
    }
}
