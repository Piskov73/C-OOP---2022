namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double INCREASED_CAR = 0.9;
        public Car(double fuelQuantity, double feleConsumption ,double tankCapasiti)
            : base(fuelQuantity, feleConsumption, tankCapasiti, INCREASED_CAR)
        {

        }
    }
}
