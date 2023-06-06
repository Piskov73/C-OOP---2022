namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double IncreasedCar = 0.9;
        public Car(double quantityFuel, double consumption)
            : base(quantityFuel, consumption, IncreasedCar)
        {
        }
    }
}
