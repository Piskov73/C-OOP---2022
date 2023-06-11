
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
        public IVehicle CreateVehicles(string type, double fuelQuantiti, double fuelConsumption, double tankCapasity)
        {
            IVehicle vehicle;
            if (type == "Car")
            {
                vehicle = new Car(fuelQuantiti, fuelConsumption,tankCapasity);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantiti, fuelConsumption, tankCapasity);
            }
            else if (type == "Bus")
            {
                vehicle =new Bus(fuelQuantiti,fuelConsumption,tankCapasity);
            }
            else
            {
                throw new ArgumentException(string.Format(EcxeptionMessage.INVALID_VEHICLE));
            }
           
            return vehicle;
        }
    }
}
