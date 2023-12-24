namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    public class Tests
    {
        private TelevisionDevice television;
        [SetUp]
        public void Setup()
        {
            television = new TelevisionDevice("Brand", 50.50, 50, 30);
        }

        [Test]
        public void Test_Constructor()
        {
            string brand = "Brand";
            double price = 50.50;
            int screenWidth = 50;
            int screenHeigth = 30;

            television = new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            Assert.NotNull(television);

            Assert.AreEqual(brand, television.Brand);
            Assert.AreEqual(price, television.Price);
            Assert.AreEqual(screenHeigth, television.ScreenHeigth);
            Assert.AreEqual(screenWidth, television.ScreenWidth);
            Assert.AreEqual(0, television.CurrentChannel);
            Assert.AreEqual(13, television.Volume);
            Assert.False(television.IsMuted);
        }
        [Test]
        public void Test_SwitchOn()
        {
            string brand = "Brand";
            double price = 50.50;
            int screenWidth = 50;
            int screenHeigth = 30;

            television = new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            string sound = television.IsMuted ? "Off" : "On";
            string expecte =   $"Cahnnel {television. CurrentChannel} - Volume {television. Volume} - Sound {sound}";
            string actual = television.SwitchOn();

            Assert.AreEqual(expecte, actual);

            television.MuteDevice();
            sound = television.IsMuted ? "Off" : "On";
            expecte = $"Cahnnel {television.CurrentChannel} - Volume {television.Volume} - Sound {sound}";
             actual = television.SwitchOn();

            Assert.AreEqual(expecte, actual);
        }
        [Test]
        public void Test_ChangeChannel()
        {
            string brand = "Brand";
            double price = 50.50;
            int screenWidth = 50;
            int screenHeigth = 30;

            television = new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            int channel = 5;

            Assert.AreEqual(channel,television.ChangeChannel(channel));

            Assert.Throws<ArgumentException>(() => television.ChangeChannel(-5), "Invalid key!");
        }
        [Test]
        public void Test_VolumeChange()
        {
            string up = "UP";
            string down = "DOWN";

            int units = 5;
            int lastVolume = television.Volume;
            
            string expecte= $"Volume: {lastVolume+units}";
            string actual = television.VolumeChange(up, units);
            Assert.AreEqual(expecte, actual);

            lastVolume = television.Volume;
            expecte = $"Volume: {lastVolume - units}";
            actual = television.VolumeChange(down, units);
            Assert.AreEqual(expecte, actual);

            units = 200;
            expecte = $"Volume: 100";
            Assert.AreEqual(expecte,television.VolumeChange(up,units));

            expecte = $"Volume: 0";

            Assert.AreEqual(expecte, television.VolumeChange(down, units));
        }
        [Test]
        public void Test_MuteDevice()
        {
            Assert.True(television.MuteDevice());

            Assert.False(television.MuteDevice());
        }

        [Test]
        public void Test_ToString()
        {
            string brand = "Brand";
            double price = 50.50;
            int screenWidth = 50;
            int screenHeigth = 30;

            television = new TelevisionDevice(brand, price, screenWidth, screenHeigth);

            string expecte= $"TV Device: {brand}, Screen Resolution: {screenWidth}x{screenHeigth}, Price {price}$";

            string actual= television.ToString();

            Assert.AreEqual(expecte , actual);
        }
    }
}