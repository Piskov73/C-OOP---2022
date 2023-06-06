namespace Vehicles.Factories
{
    using Exceptions;
    using Interface;
    using Models.Interface;
    using Vehicles.Models;

    public class VehiclesFacktorie : IVehiclesFactories
    {
        public VehiclesFacktorie()
        {
            
        }
        public IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption)
        {
            IVehicle vehicle;
            if (type == "Car")
            {
                vehicle= new Car(fuelQuantity, fuelConsumption);
            }
            else if (type == "Truck")
            {
                vehicle=new Truck(fuelQuantity, fuelConsumption);
            }
            else
            {
                throw new ExceptionInvalidVehicle();
            }
            return vehicle;
        }
    }
}
