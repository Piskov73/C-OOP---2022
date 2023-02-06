

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        
        private const double DEFAUT_FUEL_CAR_COMSUMPTION = 3;
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            
        }
        public override double FuelConsumption => DEFAUT_FUEL_CAR_COMSUMPTION;
    }
}
