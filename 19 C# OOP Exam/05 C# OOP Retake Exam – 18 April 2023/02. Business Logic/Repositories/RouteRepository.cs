using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private List<IRoute> routes;
        public RouteRepository()
        {
            this.routes = new List<IRoute>();
        }
        public void AddModel(IRoute model)
        {
            routes.Add(model);
        }

        public IRoute FindById(string identifier)
        {
            return routes.FirstOrDefault(x => x.RouteId == int.Parse(identifier));
        }

        public IReadOnlyCollection<IRoute> GetAll() => routes.AsReadOnly();


        public bool RemoveById(string identifier)
        {
            return routes.Remove(FindById(identifier));
        }
    }
}
