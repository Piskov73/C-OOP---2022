using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Linq;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> bookings;
        public Hotel(string fullName, int category)
        { 
            this.FullName = fullName;
            this.category = category;
            this.rooms = new RoomRepository();
            this.bookings = new BookingRepository();
        }
        public string FullName
        {
            get => fullName;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.HotelNameNullOrEmpty));
                }
                fullName = value;
            }
        }

        public int Category
        {
            get=>category;
            private set
            {
                if(value<1||value>5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCategory));
                }
                category = value;
            }
        }

        public double Turnover => AllBookinfsSum();

        public IRepository<IRoom> Rooms => this.rooms;

        public IRepository<IBooking> Bookings => this.bookings;

        private double AllBookinfsSum()
        {
            double sum = 0;
            foreach (var item in bookings.All())
            {
                sum += item.Room.PricePerNight * item.ResidenceDuration;
            }

            return Math.Round(sum,2);
        }
    }
}
