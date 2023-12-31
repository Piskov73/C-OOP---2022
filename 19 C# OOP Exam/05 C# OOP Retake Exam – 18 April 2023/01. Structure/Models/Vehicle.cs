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
            this.maxMileage = maxMileage;
            this.LicensePlateNumber = licensePlateNumber;
            this.batteryLevel = 100;
            this.isDamaged = false;
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

        public double MaxMileage => this.maxMileage;

        public string LicensePlateNumber
        {
            get => licensePlateNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.LicenceNumberRequired));

                licensePlateNumber =value;
            }
        }

        public int BatteryLevel =>this.BatteryLevel;

        public bool IsDamaged => this.isDamaged;
        public virtual void Drive(double mileage)
        {
            double multiplierMileage = mileage / MaxMileage;
            double bateriStatus =Math.Round( multiplierMileage * BatteryLevel);
            this.batteryLevel = (int)bateriStatus;
        }

        public void ChangeStatus()
        {
            this.isDamaged=!this.isDamaged;
        }


        public void Recharge()
        {
            this.batteryLevel = 100;
        }

        public override string ToString()
        {
            string status = "OK";
            if (IsDamaged)
            {
                status = "damaged";
            }
            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {status}";
        }
    }
}
