namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        private Device device;
        [SetUp]
        public void Setup()
        {
            device = new Device(512);
        }

        [Test]
        public void Test_DeviceConstructor()
        {
            int capacity = 512;
            device = new Device(capacity);
            Assert.IsNotNull(device);

            Assert.That(device.MemoryCapacity, Is.EqualTo(capacity));
            Assert.That(device.AvailableMemory, Is.EqualTo(capacity));
            Assert.That(device.Photos, Is.EqualTo(0));
            Assert.That(device.Applications.Count, Is.EqualTo(0));

        }
        [Test]
        public void Test_TakePhoto()
        {
            int sizeFoto = 10;
            int capacity = 512;
            device = new Device(capacity);

            Assert.True(device.TakePhoto(sizeFoto));
            Assert.True(device.TakePhoto(sizeFoto));
            Assert.True(device.TakePhoto(sizeFoto));

            Assert.That(device.AvailableMemory, Is.EqualTo(capacity - 3 * sizeFoto));

            Assert.That(device.Photos, Is.EqualTo(3));

            Assert.False(device.TakePhoto(500));

            Assert.That(device.AvailableMemory, Is.EqualTo(capacity - 3 * sizeFoto));

            Assert.That(device.Photos, Is.EqualTo(3));
        }
        [Test]
        public void Test_InstallApp()
        {
            int sizeFoto = 10;
            int capacity = 512;
            int sizeApp = 20;
            string nameApp1 = "Name1";
            string nameApp2 = "Name2";
            string nameApp3 = "Name3";
            device = new Device(capacity);

            Assert.True(device.TakePhoto(sizeFoto));
            Assert.True(device.TakePhoto(sizeFoto));
            Assert.True(device.TakePhoto(sizeFoto));

            string expecte = $"{nameApp1} is installed successfully. Run application?";
            string actual = device.InstallApp(nameApp1, sizeApp);

            Assert.That(actual, Is.EqualTo(expecte));

            expecte = $"{nameApp2} is installed successfully. Run application?";
            actual = device.InstallApp(nameApp2, sizeApp);

            Assert.That(actual, Is.EqualTo(expecte));

            Assert.Throws<InvalidOperationException>(() => device.InstallApp(nameApp3, 500)
            , "Not enough available memory to install the app.");

        }
        [Test]
        public void Test_FormatDevice()
        {
            int sizeFoto = 10;
            int capacity = 512;
            int sizeApp = 20;
            string nameApp1 = "Name1";
            string nameApp2 = "Name2";
            string nameApp3 = "Name3";
            device = new Device(capacity);

            Assert.True(device.TakePhoto(sizeFoto));
            Assert.True(device.TakePhoto(sizeFoto));
            Assert.True(device.TakePhoto(sizeFoto));

            device.InstallApp(nameApp1, sizeApp);
            device.InstallApp(nameApp2, sizeApp);
            device.InstallApp(nameApp3, sizeApp);

            int expecte = capacity - 3 * sizeFoto - 3 * sizeApp;
            int actual = device.AvailableMemory;

            Assert.That(actual,Is.EqualTo(expecte));

            Assert.That(3, Is.EqualTo(device.Applications.Count));

            device.FormatDevice();

            Assert.That(capacity, Is.EqualTo(device.AvailableMemory));
            Assert.That(0,Is.EqualTo(device.Photos));
            Assert.That(0,Is.EqualTo(device.Applications.Count));
            
        }
        [Test]
        public void Test_GetDeviceStatus()
        {
            int sizeFoto = 10;
            int capacity = 512;
            int sizeApp = 20;
            string nameApp1 = "Name1";
            string nameApp2 = "Name2";
            string nameApp3 = "Name3";
            device = new Device(capacity);

            Assert.True(device.TakePhoto(sizeFoto));
            Assert.True(device.TakePhoto(sizeFoto));
            Assert.True(device.TakePhoto(sizeFoto));

            device.InstallApp(nameApp1, sizeApp);
            device.InstallApp(nameApp2, sizeApp);
            device.InstallApp(nameApp3, sizeApp);

            StringBuilder sb=new StringBuilder();

            sb.AppendLine($"Memory Capacity: {capacity} MB, Available Memory: {device.AvailableMemory} MB");
            sb.AppendLine($"Photos Count: {device.Photos}");
            sb.AppendLine($"Applications Installed: {string.Join(", ", device.Applications)}");

            string expecte=sb.ToString().TrimEnd();

            string actual = device.GetDeviceStatus();

            Assert.That(actual,Is.EqualTo(expecte));
        }
    }
}