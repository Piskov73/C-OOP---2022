namespace Vehicles.Models
{
    using System;

    using Interfaces;
    using Messages;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;


        protected Vehicle(double fuelQuantity, double feleConsumption, double tankCapacity, double increased)
        {
            this.TankCapacity = tankCapacity;
            this.FuelConsumption = feleConsumption;
            this.Increased = increased;
            this.FuelQuantity = fuelQuantity;
        }
        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }

            private set
            {
                if(value< 0)
                {
                    throw new InvalidOperationException(string.Format(EcxeptionMessage.FUEL_CANNOT_BE_NEGATIVE));
                }
                if (value > this.TankCapacity)
                {
                    value = 0;
                }
                
              
                fuelQuantity = value;
            }
        }
        public double FuelConsumption { get; private set; }
        public double TankCapacity { get; private set; }
        public double Increased { get; private set; }


        public string Drive(double distance)
        {
            double spentFuel = (this.FuelConsumption + this.Increased) * distance;
            if (spentFuel > this.FuelQuantity)
            {
                throw new ArgumentException(string.Format(EcxeptionMessage.NEEDS_REFUELING, this.GetType().Name));
            }
            this.FuelQuantity -= spentFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public string DriveEmpty(double distance)
        {
            double spentFuel = this.FuelConsumption * distance;
            if (spentFuel > this.FuelQuantity)
            {
                throw new ArgumentException(string.Format(EcxeptionMessage.NEEDS_REFUELING, this.GetType().Name));
            }
            this.FuelQuantity -= spentFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new InvalidOperationException(string.Format(EcxeptionMessage.FUEL_CANNOT_BE_NEGATIVE));
            }
            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new InvalidOperationException(string.Format(EcxeptionMessage.FUEL_CANNOT_FIT, liters));
            }

            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }


    }
}
