using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings.Models
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
            this.room = room;
            this.ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount=childrenCount;
            this.bookingNumber = bookingNumber;
        }
        public IRoom Room => this.room;


        public int ResidenceDuration
        {
            get { return residenceDuration; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.DurationZeroOrLess));
                }
                residenceDuration = value;
            }
        }


        public int AdultsCount
        {
            get { return adultsCount; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.AdultsZeroOrLess));
                }
                adultsCount = value;
            }
        }


        public int ChildrenCount
        {
            get { return childrenCount; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ChildrenNegative));
                }
                childrenCount = value;
            }
        }


        public int BookingNumber => this.bookingNumber;

        public string BookingSummary()
        {
            double totalPaid = ResidenceDuration * Room.PricePerNight;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booking number: {BookingNumber}")
                .AppendLine($"Room type: {this.GetType().Name}")
                .AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}")
                .AppendLine($"Total amount paid: {totalPaid:F2} $");


            return sb.ToString().TrimEnd();
        }
    }
}
