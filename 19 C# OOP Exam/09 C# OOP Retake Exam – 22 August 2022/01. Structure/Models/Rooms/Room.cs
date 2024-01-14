using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private int bedCapacity;
        private double pricePerNight;
        public Room(int bedCapacity)
        { 
            this.bedCapacity=bedCapacity;
        }
        public int BedCapacity => this.BedCapacity;

        public double PricePerNight
        {
            get => pricePerNight;
            private set
            {
                if(value<0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PricePerNightNegative));
                }
                pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            this.PricePerNight= price; ;
        }
    }
}
