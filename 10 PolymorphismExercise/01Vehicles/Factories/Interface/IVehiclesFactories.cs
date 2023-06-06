namespace Vehicles.Factories.Interface
{
using Models.Interface;
    public interface IVehiclesFactories
    {
        IVehicle CreateVehicle(string type, double fuelQuantity,double fuelConsumption);
    }
}
