using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> all;
        public RoomRepository()
        {
            this.all= new List<IRoom>();
        }
        public void AddNew(IRoom model)
        {
            this.all.Add(model);
        }

        public IReadOnlyCollection<IRoom> All()=>this.all.AsReadOnly();
       

        public IRoom Select(string criteria)
        {
            return this.all.FirstOrDefault(x => x.GetType().Name == criteria);
        }
    }
}
