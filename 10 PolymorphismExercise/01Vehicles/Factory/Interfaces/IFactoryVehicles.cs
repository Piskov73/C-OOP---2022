namespace Vehicles.Factory.Intervaces
{
    using Models.Interfaces;
    public interface IFactoryVehicles
    {
        IVehicle CreateVehicles(string type, double fuelQuantiti, double fuelConsumption);
    }
}
