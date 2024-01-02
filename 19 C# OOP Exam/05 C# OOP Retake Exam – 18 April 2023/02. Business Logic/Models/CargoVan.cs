namespace EDriveRent.Models
{
    public class CargoVan : Vehicle
    {
        private const double MAX_MILAEGE = 180.0;

        public CargoVan(string brand, string model, string licensePlateNumber) 
            : base(brand, model, MAX_MILAEGE, licensePlateNumber)
        {
        }
    }
}
