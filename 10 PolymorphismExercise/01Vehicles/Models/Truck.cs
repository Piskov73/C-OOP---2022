namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double IncreasedConsumptionTruck = 1.6;
        public Truck(double quantityFuel, double consumption) : base(quantityFuel, consumption, IncreasedConsumptionTruck)
        {

        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters*0.95);
        }
    }
}
