
namespace Vehicles.Factory
{
    using System;

    using Intervaces;
    using Models;
    using Models.Interfaces;
    using Messages;
    public class FactoryVehicles : IFactoryVehicles
    {
        public FactoryVehicles()
        {

        }
        public IVehicle CreateVehicles(string type, double fuelQuantiti, double fuelConsumption)
        {
            IVehicle vehicle;
            if (type == "Car")
            {
                vehicle = new Car(fuelQuantiti, fuelConsumption);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantiti, fuelConsumption);
            }
            else
            {
                throw new ArgumentException(string.Format(EcxeptionMessage.INVALID_VEHICLE));
            }
           
            return vehicle;
        }
    }
}
