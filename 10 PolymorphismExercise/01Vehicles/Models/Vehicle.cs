namespace Vehicles.Models
{
    using Exceptions;

    using Interface;
    using Vehicles.Messages;

    public abstract class Vehicle : IVehicle
    {
        public Vehicle(double quantityFuel, double consumption, double increased)
        {
            this.QuantityFuel = quantityFuel;
            this.Consumption = consumption + increased;
        }
        public double QuantityFuel { get; private set; }

        public double Consumption { get; private set; }

        public string Drive(double distance)
        {
            double spentFuel = distance * Consumption;
            if (spentFuel > this.QuantityFuel)
            {
                throw new ExeptionNeedsRefueling(string.Format(Message.NeedsRefueling, this.GetType().Name));
            }
            this.QuantityFuel -= spentFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            this.QuantityFuel += liters;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.QuantityFuel:F2}";
        }
    }
}
