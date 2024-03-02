using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var hotel = this.hotels.Select(hotelName);

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

            if (room.PricePerNight != default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CannotResetInitialPrice));
            }

            room.SetPrice(price);

            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            List<IHotel> hotelsCategory = this.hotels.All().Where(x => x.Category == category).OrderBy(x => x.FullName).ToList();

            if (hotelsCategory.Count == 0)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }
            int numberPeople = adults + children;

            IHotel hotel = hotelsCategory.FirstOrDefault(x => x.Rooms.All()
            .Any(x => x.BedCapacity >= numberPeople && x.PricePerNight > 0));

            if (hotel == null)
            {
                return string.Format(OutputMessages.RoomNotAppropriate);
            }

            List<IRoom> rooms = hotel.Rooms.All().Where(x => x.BedCapacity >= numberPeople && x.PricePerNight > 0)
                .OrderBy(x => x.BedCapacity).ToList();

            IRoom room = rooms.First(x=>x.BedCapacity>=numberPeople&&x.PricePerNight>0);

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
                .AppendLine($"--Turnover: {hotel.Turnover:f2} $")
                .AppendLine("--Bookings:");
            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine()
                    .AppendLine("none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine()
                   .AppendLine(booking.BookingSummary());
                }
            }

            return sb.ToString().TrimEnd();
        }


    }
}
