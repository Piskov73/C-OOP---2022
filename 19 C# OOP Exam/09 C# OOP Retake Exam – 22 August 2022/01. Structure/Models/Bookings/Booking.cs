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
            this.room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.bookingNumber = bookingNumber;
        }
        public IRoom Room => this.room;

        public int ResidenceDuration
        {
            get => residenceDuration;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.DurationZeroOrLess));
                }
                residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get => adultsCount;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.AdultsZeroOrLess));
                }
                adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get => childrenCount;
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
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booking number: {BookingNumber}")
                .AppendLine($"Room type: {this.GetType().Name}")
                .AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}")
                .AppendLine($"Total amount paid: {TotalPaid():F2} $");

            return sb.ToString().TrimEnd();
        }
        public double TotalPaid()
        {
            return Math.Round(this.room.PricePerNight * this.residenceDuration, 2);
        }
    }
}
