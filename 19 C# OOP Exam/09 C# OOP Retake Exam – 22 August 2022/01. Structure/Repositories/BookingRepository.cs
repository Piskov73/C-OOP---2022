using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> all;
        public BookingRepository() 
        { 
            this.all = new List<IBooking>();
        }
        public void AddNew(IBooking model)
        {
            this.all.Add(model);
        }

        public IReadOnlyCollection<IBooking> All() => this.all.AsReadOnly();
        

        public IBooking Select(string criteria)
        {
            return this.all.FirstOrDefault(x=>x.BookingNumber==int.Parse(criteria));
        }
    }
}
