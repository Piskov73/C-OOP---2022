using System;
using System.Collections.Generic;
using System.Text;

namespace EDriveRent.Models
{
    public class CargoVan : Vehicle
    {
        private const double maxMileage = 150;
        public CargoVan(string brand, string model,  string licensePlateNumber)
            : base(brand, model, maxMileage, licensePlateNumber)
        {

        }

        public override void Drive(double mileage)
        {
            base.Drive(mileage*1.05);
        }
    }
}
