namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        private Device device = null;
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void Test_ConstructorCorrectArguments()
        {
            device = new Device(512);

            Assert.AreEqual(512, device.MemoryCapacity);
            Assert.AreEqual(512, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0, device.Applications.Count);
        }
        [Test]
        public void Test_TakePhotoMethodCorrect()
        {
            device = new Device(512);

            int photoSize = 100;

            Assert.True(device.TakePhoto(photoSize));
            Assert.AreEqual(412, device.AvailableMemory);
            Assert.AreEqual(1, device.Photos);
        }

        [Test]
        public void Test_TakePhotoMethodIncorrect()
        {
            device = new Device(512);

            int photoSize = 600;

            Assert.False(device.TakePhoto(photoSize));
            Assert.AreEqual(512, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);

        }
        [Test]
        public void Test_InstallAppMethodCorrect()
        {
            device = new Device(512);

            string appName = "Test";
            int appSize = 100;

            string expected = $"{appName} is installed successfully. Run application?";

            string aktual = device.InstallApp(appName, appSize);

            Assert.AreEqual(expected, aktual);
            Assert.AreEqual(412, device.AvailableMemory);
            Assert.AreEqual(1, device.Applications.Count);
            Assert.AreEqual(0, device.Photos);



        }
        [Test]
        public void Test_InstallAppMethodIncorrect()
        {
            device = new Device(512);

            string appName = "Test";
            int appSize = 600;

            Assert.Throws<InvalidOperationException>(() => device.InstallApp(appName, appSize)
                                          , "Not enough available memory to install the app.");

            Assert.AreEqual(512, device.AvailableMemory);
            Assert.AreEqual(0, device.Applications.Count);
            Assert.AreEqual(0, device.Photos);


        }
        [Test]
        public void Test_FormatDeviceMethod()
        {
            device = new Device(512);

            string appName = "Test";
            int appSize = 100;
            int photoSize = 100;

            device.InstallApp(appName, appSize);
            device.TakePhoto(photoSize);

            Assert.AreEqual(1, device.Photos);
            Assert.AreEqual(1, device.Applications.Count);
            Assert.AreEqual(312, device.AvailableMemory);
            device.FormatDevice();

            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0, device.Applications.Count);
            Assert.AreEqual(512, device.AvailableMemory);



        }
        [Test]

        public void Test_GetDeviceStatusMethod()
        {
            int memoryCapacity = 512;

            device = new Device(memoryCapacity);

            string appName = "Test";
            string appName1 = "Test1";
            int appSize = 100;
            int photoSize = 100;

            device.InstallApp(appName, appSize);
            device.TakePhoto(photoSize);
            device.InstallApp(appName1, appSize);

            string output=string.Join(", ",device.Applications);

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Memory Capacity: {device.MemoryCapacity} MB, Available Memory: {device.AvailableMemory} MB");
            stringBuilder.AppendLine($"Photos Count: {device.Photos}");
            stringBuilder.AppendLine($"Applications Installed: {output}");

            string expected= stringBuilder.ToString().TrimEnd();
            string actual = device.GetDeviceStatus();

            Assert.AreEqual(expected, actual);
        }


    }
}