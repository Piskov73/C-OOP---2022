using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> users;
        public UserRepository()
        {
            this.users = new List<IUser>();
        }
        public void AddModel(IUser model)
        {
           this.users.Add(model);
        }

        public IUser FindById(string identifier)
        {
            return this.users.FirstOrDefault(x=>x.DrivingLicenseNumber== identifier);
        }

        public IReadOnlyCollection<IUser> GetAll() => this.users.AsReadOnly();
       

        public bool RemoveById(string identifier)
        {
            return this.users.Remove(FindById(identifier));
        }
    }
}
