
using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Text;

namespace EDriveRent.Models
{
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
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
            this.batteryLevel = 100;
            this.isDamaged = false;
        }
        public string Brand
        {
            get { return brand; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.BrandNull));
                }
                brand = value;
            }
        }


        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ModelNull));
                }
                model = value;
            }
        }


        public double MaxMileage { get => maxMileage; private set => maxMileage = value; }


        public string LicensePlateNumber
        {
            get { return licensePlateNumber; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.LicenceNumberRequired));
                }
                licensePlateNumber = value;
            }
        }

        public int BatteryLevel { get => batteryLevel; private set => batteryLevel = value; }

        public bool IsDamaged { get => isDamaged; private set => isDamaged = value; }

        public virtual void Drive(double mileage)
        {
            int consumptionBattery = (int)Math.Round((mileage / this.maxMileage * 1000), 0);
            this.batteryLevel -= consumptionBattery;

        }

        public void ChangeStatus()
        {
           if(!IsDamaged)
            {
                this.isDamaged=true;
            }
            else
            {
                this.isDamaged = false;
            }
        }



        public void Recharge()
        {
            this.batteryLevel = 100;
        }
        public override string ToString()
        {
            string status = IsDamaged ? "damaged" : "OK";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {status}");
             


            return sb.ToString().TrimEnd();
        }
    }
}
