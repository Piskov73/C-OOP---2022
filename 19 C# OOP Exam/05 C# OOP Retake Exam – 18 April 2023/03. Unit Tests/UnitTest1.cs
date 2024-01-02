using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        private Vehicle vehicle;
        private Garage garage;

        [SetUp]
        public void Setup()
        {
            vehicle = new Vehicle("Brand", "Model", "CA0000");
            garage = new Garage(1);
        }
        [Test]
        public void Test_VehicleConstructor()
        {

            string brand = "Brand";
            string model = "Model";
            string number = "CA0000";

            vehicle=new Vehicle(brand, model, number);

            Assert.NotNull(vehicle);
            Assert.That(vehicle.Brand, Is.EqualTo(brand));
            Assert.That(vehicle.Model, Is.EqualTo(model));
            Assert.That(vehicle.LicensePlateNumber, Is.EqualTo(number));
            Assert.That(vehicle.BatteryLevel, Is.EqualTo(100));
            Assert.False(vehicle.IsDamaged);
        }
        [Test]
        public void Test_GarageConstructor()
        {
            int capasity = 5;

            garage=new Garage(capasity);

            Assert.NotNull(garage);
            Assert.That(garage.Capacity, Is.EqualTo(capasity));
            Assert.NotNull(garage.Vehicles);
        }
        [Test]
        public void Test_GarageAddVehicle()
        {
            int capasity = 2;

            garage = new Garage(capasity);
            string brand = "Brand";
            string model = "Model";
            string number = "CA0000";

            vehicle = new Vehicle(brand, model, number);

            Assert.True(garage.AddVehicle(vehicle));
            Assert.False(garage.AddVehicle(vehicle));
            Assert.True(garage.AddVehicle(new Vehicle(brand ,model,"CA1111")));
            Assert.False(garage.AddVehicle(new Vehicle(brand ,model,"CA2222")));

        }
        [Test]
        public void Test_GarageDriveVehicle()
        {
            int capasity = 3;

            garage = new Garage(capasity);
            string brand = "Brand";
            string model = "Model";
            string number = "CA0000";

            vehicle = new Vehicle(brand, model, number);

            garage.AddVehicle(vehicle);
            garage.AddVehicle(new Vehicle(brand, model, "CA1111"));
            garage.AddVehicle(new Vehicle(brand, model, "CA3333"));

            garage.DriveVehicle(number, 50, true);
            garage.DriveVehicle("CA1111", 50, false);
            garage.DriveVehicle("CA3333", 120, false);

            Assert.That(vehicle.BatteryLevel, Is.EqualTo(50));
            Assert.True(vehicle.IsDamaged);
        }
        [Test]
        public void Test_GarageChargeVehicles()
        {
            int capasity = 3;

            garage = new Garage(capasity);
            string brand = "Brand";
            string model = "Model";
            string number = "CA0000";

            vehicle = new Vehicle(brand, model, number);

            garage.AddVehicle(vehicle);
            garage.AddVehicle(new Vehicle(brand, model, "CA1111"));
            garage.AddVehicle(new Vehicle(brand, model, "CA3333"));

            garage.DriveVehicle(number, 50, true);
            garage.DriveVehicle("CA1111", 50, false);
            garage.DriveVehicle("CA3333", 120, false);

            Assert.That(vehicle.BatteryLevel, Is.EqualTo(50));

            Assert.That(garage.ChargeVehicles(60), Is.EqualTo(2));

            Assert.That(vehicle.BatteryLevel, Is.EqualTo(100));
        }
        [Test]
        public void Test_GarageRepairVehicles()
        {
            int capasity = 3;

            garage = new Garage(capasity);
            string brand = "Brand";
            string model = "Model";
            string number = "CA0000";

            vehicle = new Vehicle(brand, model, number);

            garage.AddVehicle(vehicle);
            garage.AddVehicle(new Vehicle(brand, model, "CA1111"));
            garage.AddVehicle(new Vehicle(brand, model, "CA3333"));

            garage.DriveVehicle(number, 50, true);
            garage.DriveVehicle("CA1111", 50, false);
            garage.DriveVehicle("CA3333", 120, false);

            Assert.True(vehicle.IsDamaged);

            string expected = "Vehicles repaired: 1";
            string actual = garage.RepairVehicles();

            Assert.That(actual, Is.EqualTo(expected));

            Assert.False(vehicle.IsDamaged);
        }
    }
}