using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> vehicles;
        public VehicleRepository()
        {
            this.vehicles=new List<IVehicle>();
        }
        public IReadOnlyCollection<IVehicle> GetAll()=>this.vehicles.AsReadOnly();

        public void AddModel(IVehicle model)
        {
            this.vehicles.Add(model);
        }

        public IVehicle FindById(string identifier)
        {
            return this.vehicles.FirstOrDefault(x=>x.LicensePlateNumber==identifier);
        }


        public bool RemoveById(string identifier)
        {
            return this.vehicles.Remove(FindById(identifier));
        }
    }
}
