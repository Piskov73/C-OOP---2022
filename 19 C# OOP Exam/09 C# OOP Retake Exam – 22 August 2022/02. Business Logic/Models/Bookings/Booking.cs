using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private IRoom room;
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;
        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber) 
        { 
            this.room=room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            this.bookingNumber=bookingNumber;
        }
        public IRoom Room => this.room;

        public int ResidenceDuration
        {
            get => this.residenceDuration;
            private set
            {
                if(value<=0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.DurationZeroOrLess));
                }
                this.residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get=>this.adultsCount;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.AdultsZeroOrLess));
                }
                this.adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get => this.childrenCount;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ChildrenNegative));
                }
                this.childrenCount = value;
            }
        }

        public int BookingNumber => this.bookingNumber;

        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booking number: {BookingNumber}")
                .AppendLine($"Room type: {Room.GetType().Name}")
                .AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}")
                .AppendLine($"Total amount paid: {TotalPaid():F2} $");

            return sb.ToString().TrimEnd();
        }

        private double TotalPaid()
        {
            return Math.Round(ResidenceDuration * room.PricePerNight,2);
        }
    }
}
