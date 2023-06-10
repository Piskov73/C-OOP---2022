namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        double Increased { get; }
        string Drive(double distance);
        void Refuel(double liters);
    }
}
