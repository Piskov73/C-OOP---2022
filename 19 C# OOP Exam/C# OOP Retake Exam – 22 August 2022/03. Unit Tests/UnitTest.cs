using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
      private  Hotel hotel;
        private Room room;
        [SetUp]
        public void Setup()
        {
            hotel = new Hotel("Zvezdobroi", 4);
            room = new Room(3, 23.50);
        }

        [Test]
        public void Test_ConstructorHotel()
        {
            string name = "Zbezda";
            int category = 4;
            hotel=new Hotel(name, category);
            Assert.NotNull(hotel);
            Assert.AreEqual(name, hotel.FullName);
            Assert.AreEqual(category, hotel.Category);
            Assert.AreEqual(0, hotel.Rooms.Count);
            Assert.AreEqual(0, hotel.Bookings.Count);

        }

        [Test]
        public void Test_HotelNameNuui()
        {
            string name = null;
            int category = 4;
            Assert.Throws<ArgumentNullException>(()=>new  Hotel(name, category));

        }
        [Test]
        public void Test_InvalidCategory()
        {
            string name = "Zvezda";
            int category = 8;
            Assert.Throws<ArgumentException>(() => new Hotel(name, category));

        }
        [Test]
        public void Test_AddRoom()
        {
            hotel.AddRoom(room);
            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_BookRoom()
        {
            hotel.AddRoom(room);

            //int adults, int children, int residenceDuration, double budget
            int adults = 1;
            int children = 2;
            int residenceDuration = 3;
                double budget = 100;

            Assert.Throws<ArgumentException>(()=>hotel.BookRoom(0, children, residenceDuration, budget));
            Assert.Throws<ArgumentException>(()=>hotel.BookRoom(1, -1, residenceDuration, budget));
            Assert.Throws<ArgumentException>(()=>hotel.BookRoom(1, 0, 0, budget));
            Room room2 = new Room(2, 46);
            hotel.AddRoom(room2);
            hotel.BookRoom(adults, children, residenceDuration, budget);

            Assert.AreEqual(2, hotel.Rooms.Count);

            Assert.AreEqual(1,hotel.Bookings.Count);

            Assert.AreEqual(70.50, hotel.Turnover);
        }
    }
}