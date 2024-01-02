namespace EDriveRent.Models
{
    using Contracts;
    using EDriveRent.Utilities.Messages;
    using System;

    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private double maxMileage;
        private string licensePlateNumber;
        private int batteryLevel;
        private bool isDamaged;
        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            this.Brand = brand;
            this.Model = model;
            this.MaxMileage = maxMileage;
            this.LicensePlateNumber = licensePlateNumber;
            this.BatteryLevel = 100;
            this.IsDamaged = false;
        }

        public string Brand
        {
            get => brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.BrandNull));

                brand = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.ModelNull));

                model = value;
            }
        }

        public double MaxMileage { get => maxMileage; private set => maxMileage = value; }

        public string LicensePlateNumber
        {
            get => licensePlateNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.LicenceNumberRequired));

                licensePlateNumber = value;
            }
        }

        public int BatteryLevel { get => batteryLevel; private set => batteryLevel = value; }

        public bool IsDamaged { get => isDamaged; private set => isDamaged = value; }
        public  void Drive(double mileage)
        {
            double tempBaatteryLevel =Math.Round ( 100 * (mileage / MaxMileage));
            this.BatteryLevel-=(int)tempBaatteryLevel;
            if (this.GetType().Name == nameof(CargoVan))
            {
                this.BatteryLevel -= 5;
            }
            
        }
        public void Recharge()
        {
            BatteryLevel = 100;
        }

        public void ChangeStatus()
        {
           IsDamaged=!IsDamaged;
        }

        public override string ToString()
        {
            string ststus = IsDamaged ? "damaged" : "OK";

            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {ststus}";
        }
    }
}
