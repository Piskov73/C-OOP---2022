

namespace NeedForSpeed
{
    public class SportCar : Car
    {
       
        private const double DEFAUT_SPORT_CAR_FUEL_CONSUMPTION = 10;
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
        public override double FuelConsumption => DEFAUT_SPORT_CAR_FUEL_CONSUMPTION;
    }
}
