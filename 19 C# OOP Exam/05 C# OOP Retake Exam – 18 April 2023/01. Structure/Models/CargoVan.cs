namespace EDriveRent.Models
{
    public class CargoVan : Vehicle
    {
        private const double MAX_MILAGE = 180;
        public CargoVan(string brand, string model, string licensePlateNumber) 
            : base(brand, model, MAX_MILAGE, licensePlateNumber)
        {
        }
        public override void Drive(double mileage)
        {
            base.Drive(mileage*1.05);
        }
    }
}
