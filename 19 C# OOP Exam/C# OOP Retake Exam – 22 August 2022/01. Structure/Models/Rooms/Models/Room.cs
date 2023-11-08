using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;

namespace BookingApp.Models.Rooms.Models
{
    public class Room : IRoom
    {
        private int bedCapacity;

        public Room(int bedCapacity)
        {
            BedCapacity=bedCapacity;
        }
        public int BedCapacity { get =>bedCapacity;  private set => bedCapacity = value; }

        private double pricePerNight;

        public double PricePerNight
        {
            get { return pricePerNight; }
          private set 
            {
                if(value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PricePerNightNegative));
                }
                pricePerNight = value;
            }
        }


        public void SetPrice(double price)
        {
            PricePerNight=price;
        }
    }
}
