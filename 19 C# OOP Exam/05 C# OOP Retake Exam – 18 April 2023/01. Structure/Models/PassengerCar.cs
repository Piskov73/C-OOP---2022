namespace EDriveRent.Models
{
    public class PassengerCar : Vehicle
    {
        private const double MAX_MILAGE = 450;
        public PassengerCar(string brand, string model,  string licensePlateNumber)
            : base(brand, model, MAX_MILAGE, licensePlateNumber)
        {
        }
    }
}
