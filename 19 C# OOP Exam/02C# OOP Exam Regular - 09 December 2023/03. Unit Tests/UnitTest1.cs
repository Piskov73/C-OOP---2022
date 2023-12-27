namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        private RailwayStation station;

        [SetUp]
        public void Setup()
        {
            this.station = new RailwayStation("NameStation");
        }
        [Test]
        public void Test_RailwayStationConstruktor()
        {
            string nameStation = "NameStation";
            station = new RailwayStation(nameStation);

            Assert.AreEqual(nameStation, station.Name);
            Assert.NotNull(station);

            nameStation = null;

            Assert.Throws<ArgumentException>(()=>new RailwayStation(nameStation), "Name cannot be null or empty!");
            Assert.Throws<ArgumentException>(() => new RailwayStation(" "), "Name cannot be null or empty!");
        }
        [Test]
        public void Test_NewArrivalOnBoard()
        {
            string nameStation = "NameStation";
            station = new RailwayStation(nameStation);

            string trainInfo = "String TrainInfo";

            station.NewArrivalOnBoard(trainInfo);

            Assert.AreEqual(trainInfo, station.ArrivalTrains.Peek());
        }
        [Test]
        public void Test_TrainHasArrived()
        {
            string nameStation = "NameStation";
            station = new RailwayStation(nameStation);

            string trainInfo = "String TrainInfo";
            string trainInfo2 = "String TrainInfo2";

            station.NewArrivalOnBoard(trainInfo);

            string expektet = $"There are other trains to arrive before {trainInfo2}.";
            string actual=station.TrainHasArrived(trainInfo2);

            Assert.AreEqual(expektet, actual);

            expektet = $"{trainInfo} is on the platform and will leave in 5 minutes.";
            actual=station.TrainHasArrived(trainInfo);
            Assert.AreEqual(expektet, actual);
            Assert.AreEqual(1,station.DepartureTrains.Count);
        }

        [Test]
        public void Test_TrainHasLeft()
        {
            string nameStation = "NameStation";
            station = new RailwayStation(nameStation);

            string trainInfo = "String TrainInfo";
            string trainInfo2 = "String TrainInfo2";

            station.NewArrivalOnBoard(trainInfo);
            station.TrainHasArrived(trainInfo);

            Assert.False(station.TrainHasLeft(trainInfo2));

            Assert.True(station.TrainHasLeft(trainInfo));

            Assert.AreEqual(0, station.DepartureTrains.Count);
        }
    }
}