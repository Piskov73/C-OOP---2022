using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Rooms;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;
        public Controller()
        {
            this.hotels = new HotelRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            var hotel = hotels.Select(hotelName);
            if (hotel != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }
            hotel = new Hotel(hotelName, category);

            this.hotels.AddNew(hotel);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }
        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            var hotel = this.hotels.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            var room = hotel.Rooms.Select(roomTypeName);
            if (room != null)
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }
            if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == nameof(Studio))
            {
                room = new Studio();
            }
            else if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect));
            }

            hotel.Rooms.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            var hotel = this.hotels.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            if (roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Studio) && roomTypeName != nameof(Apartment))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect));
            }
            var room = hotel.Rooms.Select(roomTypeName);
            if (room == null)
            {
                return string.Format(OutputMessages.RoomTypeNotCreated);
            }
            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CannotResetInitialPrice));
            }
            room.SetPrice(price);

            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
          



            int sumAdultsChildren = adults + children;

            var filter = this.hotels.All().Where(c => c.Category == category).OrderBy(n => n.Turnover).ThenBy(x=>x.FullName).ToList();
            if (filter == null)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }
            var hotel = filter.FirstOrDefault(x => x.Rooms.All().Any(r => r.PricePerNight > 0)
            && x.Rooms.All().Any(r => r.BedCapacity >= sumAdultsChildren));
            if (hotel == null)
            {
                return string.Format(OutputMessages.RoomNotAppropriate);
            }
            var rooms = hotel.Rooms.All().OrderBy(x => x.BedCapacity);
            var room = rooms.FirstOrDefault(x => x.PricePerNight > 0 && x.BedCapacity >= sumAdultsChildren);
            int bookingNumber = hotel.Bookings.All().Count + 1;
            IBooking booking = new Booking(room, duration, adults, children, bookingNumber);
            hotel.Bookings.AddNew(booking);
            return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);
        }

        public string HotelReport(string hotelName)
        {
            var hotel = this.hotels.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotelName}")
                .AppendLine($"--{hotel.Category} star hotel")
                .AppendLine($"--Turnover: {hotel.Turnover:F2} $")
                .AppendLine("--Bookings:")
                .AppendLine($"");
            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var book in hotel.Bookings.All())
                {
                    sb.AppendLine(book.BookingSummary());
                    sb.AppendLine();
                }
            }

            return sb.ToString().TrimEnd();
        }


    }
}
