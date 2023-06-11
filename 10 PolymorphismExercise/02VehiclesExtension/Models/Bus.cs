namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double INCREASED_BUS = 1.4;
        public Bus(double fuelQuantity, double feleConsumption, double tankCapacity) 
            : base(fuelQuantity, feleConsumption, tankCapacity, INCREASED_BUS)
        {
        }
    }
}
