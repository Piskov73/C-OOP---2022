using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Room room;
        private Booking booking;
        private Hotel hotel;
        [SetUp]
        public void Setup()
        {
            room = new Room(1, 1);
            booking = new Booking(1, room, 1);
            hotel = new Hotel("Hotel", 4);
        }
        [Test]
        public void Test_RoomConstructor()
        {
            int bedCapacity = 2;
            double pricePerNight = 20.00;
            room = new Room(bedCapacity, pricePerNight);

            Assert.NotNull(room);
        }
        [Test]
        public void Test_RoomBedCapacity()
        {
            int bedCapacity = 2;
            double pricePerNight = 20.00;
            room = new Room(bedCapacity, pricePerNight);

            Assert.That(room.BedCapacity, Is.EqualTo(bedCapacity));

            bedCapacity = 0;

            Assert.Throws<ArgumentException>(() => new Room(bedCapacity, pricePerNight));
        }
        [Test]
        public void Test_RoomPricePerNight()
        {
            int bedCapacity = 2;
            double pricePerNight = 20.00;
            room = new Room(bedCapacity, pricePerNight);

            Assert.That(room.PricePerNight, Is.EqualTo(pricePerNight));

            pricePerNight = 0;

            Assert.Throws<ArgumentException>(() => new Room(bedCapacity, pricePerNight));
        }
        [Test]
        public void Test_Booking()
        {
            Assert.NotNull(booking);
            Assert.NotNull(booking.BookingNumber);
            Assert.NotNull(booking.Room);
            Assert.NotNull(booking.ResidenceDuration);
        }
        [Test]
        public void Test_HotelConstructor()
        {
            Assert.NotNull(hotel);
        }
        [Test]
        public void Test_HotelFullName()
        {
            string fullName = "HotelName";
            int category = 4;
            hotel = new Hotel(fullName, category);

            Assert.That(hotel.FullName, Is.EqualTo(fullName));

            fullName = null;

            Assert.Throws<ArgumentNullException>(() => new Hotel(fullName, category));
        }
        [Test]
        public void Test_HotelCategory()
        {
            string fullName = "HotelName";
            int category = 4;
            hotel = new Hotel(fullName, category);

            Assert.That(hotel.Category, Is.EqualTo(category));

            category = 8;

            Assert.Throws<ArgumentException>(() => new Hotel(fullName, category));

            category = 0;
            Assert.Throws<ArgumentException>(() => new Hotel(fullName, category));
        }
        [Test]
        public void Test_HotelAddRoom()
        {
            string fullName = "HotelName";
            int category = 4;
            hotel = new Hotel(fullName, category);
            hotel.AddRoom(room);

            room = new Room(4, 40);
            hotel.AddRoom(room);

            Assert.That(hotel.Rooms.Count, Is.EqualTo(2));
        }
        [Test]
        public void Test_HotelBookRoom()
        {
            string fullName = "HotelName";
            int category = 4;
            hotel = new Hotel(fullName, category);
           

            room = new Room(4, 40);
            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(0, 2, 3, 1000));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, -5, 3, 1000));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, 2, 0, 1000));

            hotel.BookRoom(2, 1, 5, 1000.0);

            Assert.That(hotel.Bookings.Count, Is.EqualTo(1));
            Assert.That(hotel.Turnover, Is.EqualTo(200));

            hotel.BookRoom(2, 2, 6, 10);

            Assert.That(hotel.Bookings.Count, Is.EqualTo(1));
            Assert.That(hotel.Turnover, Is.EqualTo(200));

        }


    }
}