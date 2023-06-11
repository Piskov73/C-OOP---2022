namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double INNCREASED_TRUCK = 1.6;
        public Truck(double fuelQuantity, double feleConsumption, double tankCapasiti)
            : base(fuelQuantity, feleConsumption, tankCapasiti, INNCREASED_TRUCK)
        {
        }

       
    }
}
