using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories.Models
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

        public IReadOnlyCollection<IBooking> All()=>this.bookings.AsReadOnly();
       

        public IBooking Select(string criteria)
        {
            int id=int.Parse(criteria);
            return All().FirstOrDefault(n => n.BookingNumber == id);
        }
    }
}
