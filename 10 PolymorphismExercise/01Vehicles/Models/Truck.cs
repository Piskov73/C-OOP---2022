namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double INNCREASED_TRUCK = 1.6;
        public Truck(double fuelQuantity, double feleConsumption)
            : base(fuelQuantity, feleConsumption, INNCREASED_TRUCK)
        {
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters*0.95);
        }
    }
}
