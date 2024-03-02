using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;
        public BookingRepository() 
        { 
            this.bookings=new List<IBooking>();
        }
        public void AddNew(IBooking model)
        {
            this.bookings.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return this.bookings.AsReadOnly();
        }

        public IBooking Select(string criteria)
        {
            int id=int.Parse(criteria);

            return this.bookings.FirstOrDefault(x=>x.BookingNumber==id);
        }
    }
}
