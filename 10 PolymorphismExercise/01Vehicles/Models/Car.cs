namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double INCREASED_CAR = 0.9;
        public Car(double fuelQuantity, double feleConsumption)
            : base(fuelQuantity, feleConsumption, INCREASED_CAR)
        {

        }
    }
}
