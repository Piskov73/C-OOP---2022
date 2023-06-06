namespace Vehicles.Models.Interface
{
    public interface IVehicle
    {
        double QuantityFuel { get; }
        double Consumption { get; }
        string Drive(double distance);
        void Refuel(double liters);

    }
}
