namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double DEFAULT_FUEL_CONSUMPTION_SPORT_CAR = 10;
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
        public override double FuelConsumption => DEFAULT_FUEL_CONSUMPTION_SPORT_CAR;
    }
}
