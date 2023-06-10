namespace Vehicles.Models
{
    using System;

    using Interfaces;
    using Messages;

    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double feleConsumption, double increased)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = feleConsumption;
            this.Increased = increased;
        }
        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public double Increased { get; private set; }

        public string Drive(double distance)
        {
            double spentFuel = (this.FuelConsumption+this.Increased) * distance;
            if(spentFuel>this.FuelQuantity)
            {
               throw new ArgumentException(string.Format(EcxeptionMessage.NEEDS_REFUELING,this.GetType().Name));
            }
            this.FuelQuantity-=spentFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
