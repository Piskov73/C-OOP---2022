using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> all;
        public HotelRepository()
        {
            this.all= new List<IHotel>();
        }
        public void AddNew(IHotel model)
        {
            this.all.Add(model);
        }

        public IReadOnlyCollection<IHotel> All() => this.all.AsReadOnly();
       

        public IHotel Select(string criteria)
        {
           return this.all.FirstOrDefault(x=>x.FullName == criteria);
        }
    }
}
