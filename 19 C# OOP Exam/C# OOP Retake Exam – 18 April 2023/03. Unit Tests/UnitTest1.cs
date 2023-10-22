using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_VehicleConstruktor()
        {
            Vehicle vehicle = new Vehicle("Ford", "Fokus", "CA9999");

            Assert.IsNotNull(vehicle);
            Assert.AreEqual("Ford", vehicle.Brand);
            Assert.AreEqual("Fokus", vehicle.Model);
            Assert.AreEqual("CA9999", vehicle.LicensePlateNumber);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.IsFalse(vehicle.IsDamaged);
        }
        [Test]
        public void Test_GarageConstruktor()
        {
            Garage garage = new Garage(10);
            Assert.IsNotNull(garage);
            Assert.IsNotNull(garage.Vehicles);
            Assert.AreEqual(10, garage.Capacity);
        }
        [Test]
        public void Test_AddVehicle()
        {
            Garage garage = new Garage(2);
            Vehicle vehicle = new Vehicle("Ford", "Fokus", "CA9999");
            Vehicle vehicle1 = new Vehicle("Ford", "Fokus", "CA0000");
            Vehicle vehicle2 = new Vehicle("Ford", "Fokus", "CA1111");
           
            Assert.True(garage.AddVehicle(vehicle));
            Assert.AreEqual(1,garage.Vehicles.Count);
            Assert.False(garage.AddVehicle(vehicle));
            garage.AddVehicle(vehicle1);
            Assert.False(garage.AddVehicle(vehicle2));
            Assert.AreEqual(2,garage.Vehicles.Count);   

            

        }
        [Test]
        public void Test_DriveVehicle()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("Ford", "Fokus", "CA9999");
            Vehicle vehicle1 = new Vehicle("Ford", "Fokus", "CA0000");
            Vehicle vehicle2 = new Vehicle("Ford", "Fokus", "CA1111");
            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);

            Assert.AreEqual(3, garage.Vehicles.Count);

            garage.DriveVehicle("CA9999", 40, false);
            Assert.AreEqual(60, vehicle.BatteryLevel);
            Assert.False(vehicle.IsDamaged);
            garage.DriveVehicle("CA0000", 40, true);
            Assert.AreEqual(60, vehicle1.BatteryLevel);
            Assert.True(vehicle1.IsDamaged);

            garage.DriveVehicle("CA0000", 40, true);
            Assert.AreEqual(60, vehicle1.BatteryLevel);

            garage.DriveVehicle("CA1111", 120, false);
            Assert.AreEqual(100, vehicle2.BatteryLevel);
            Assert.False(vehicle.IsDamaged);

            garage.DriveVehicle("CA1111", 50, false);
            Assert.AreEqual(50, vehicle2.BatteryLevel);
            Assert.False(vehicle.IsDamaged);

            garage.DriveVehicle("CA1111", 60, false);
            Assert.AreEqual(50, vehicle2.BatteryLevel);
            Assert.False(vehicle.IsDamaged);

        }
        [Test]
        public void Test_ChargeVehicles()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("Ford", "Fokus", "CA9999");
            Vehicle vehicle1 = new Vehicle("Ford", "Fokus", "CA0000");
            Vehicle vehicle2 = new Vehicle("Ford", "Fokus", "CA1111");
            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);

            garage.DriveVehicle("CA9999", 40, false);
            garage.DriveVehicle("CA0000", 40, false);
            garage.DriveVehicle("CA1111", 40, false);

            Assert.AreEqual(60,vehicle.BatteryLevel);
            Assert.AreEqual(60,vehicle1.BatteryLevel);
            Assert.AreEqual(60,vehicle2.BatteryLevel);


            Assert.AreEqual(3, garage.ChargeVehicles(70));

            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.AreEqual(100, vehicle1.BatteryLevel);
            Assert.AreEqual(100, vehicle2.BatteryLevel);

            Assert.AreEqual(3, garage.Vehicles.Count);
        }

        [Test]
        public void Test_RepairVehicles()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("Ford", "Fokus", "CA9999");
            Vehicle vehicle1 = new Vehicle("Ford", "Fokus", "CA0000");
            Vehicle vehicle2 = new Vehicle("Ford", "Fokus", "CA1111");
            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);

            garage.DriveVehicle("CA9999", 40, false);
            garage.DriveVehicle("CA0000", 40, false);
            garage.DriveVehicle("CA1111", 40, false);

            string expek = $"Vehicles repaired: {0}";
            Assert.AreEqual(expek,garage.RepairVehicles());
            expek = $"Vehicles repaired: {1}";
            garage.DriveVehicle("CA9999", 40, true);
            Assert.AreEqual(expek, garage.RepairVehicles());

            Assert.AreEqual(3, garage.Vehicles.Count);
        }
    }
}