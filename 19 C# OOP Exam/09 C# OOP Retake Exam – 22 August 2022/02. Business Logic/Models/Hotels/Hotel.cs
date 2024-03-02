using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private const int MIN_CATEGORY = 1;
        private const int MAX_CATEGORY = 5;
        private string fullName;
        private int category;
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> bookings;
        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            this.rooms = new RoomRepository();
            this.bookings=new BookingRepository();
        }
        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.HotelNameNullOrEmpty));
                }
                this.fullName = value;
            }
        }

        public int Category
        {
            get => this.category;
            private set
            {
                if (value < MIN_CATEGORY || value > MAX_CATEGORY)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCategory));
                }
                this.category = value;
            }
        }

        public double Turnover => GetTurnover();
            

        public IRepository<IRoom> Rooms => this.rooms;

        public IRepository<IBooking> Bookings => this.bookings;

        private double GetTurnover()
        {
            double turnover = 0;
            foreach (var booking in this.bookings.All())
            {
                turnover += booking.ResidenceDuration * booking.Room.PricePerNight;
            }
            return turnover;
        }
    }
}
