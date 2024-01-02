namespace EDriveRent.Core
{
    using Contracts;
    using EDriveRent.Models;
    using EDriveRent.Models.Contracts;
    using EDriveRent.Repositories;
    using EDriveRent.Utilities.Messages;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Text;

    public class Controller : IController
    {
        private UserRepository useers;
        private VehicleRepository vehicles;
        private RouteRepository routes;

        public Controller()
        {
            this.useers = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }
        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            var user = this.useers.FindById(drivingLicenseNumber);

            if (user != null)
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);

            user = new User(firstName, lastName, drivingLicenseNumber);

            this.useers.AddModel(user);

            return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }
        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            IVehicle vehicle;

           

            if (vehicleType == nameof(PassengerCar))
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }
            else if (vehicleType == nameof(CargoVan))
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }
            else
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }

            if (this.vehicles.GetAll().Any(x=>x.LicensePlateNumber == licensePlateNumber))
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);

            this.vehicles.AddModel(vehicle);

            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            if (this.routes.GetAll().Any(x => x.StartPoint == startPoint && x.EndPoint == endPoint && x.Length == length))
            {
                return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }
            if (this.routes.GetAll().Any(x => x.StartPoint == startPoint && x.EndPoint == endPoint && x.Length < length))
            {
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }

            int id = this.routes.GetAll().Count + 1;

            var route = new Route(startPoint, endPoint, length, id);

            if (this.routes.GetAll().Any(x => x.StartPoint == startPoint && x.EndPoint == endPoint && x.Length > length))
            {
                this.routes.GetAll()
                    .First(x => x.StartPoint == startPoint && x.EndPoint == endPoint && x.Length > length).LockRoute();
            }

            this.routes.AddModel(route);
            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint,length);
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            var user = this.useers.FindById(drivingLicenseNumber);
            var car =this.vehicles.FindById(licensePlateNumber);
            var route = this.routes.FindById(routeId);
            if (user.IsBlocked)
            {
                return string.Format(OutputMessages.UserBlocked,drivingLicenseNumber);
            }
            if(car.IsDamaged)
            {
                return string.Format(OutputMessages.VehicleDamaged,licensePlateNumber );
            }
            if (route.IsLocked)
            {
                return string.Format(OutputMessages.RouteLocked,routeId );
            }

            car.Drive(route.Length);
            if(isAccidentHappened )
            {
                car.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return car.ToString();
        }


        public string RepairVehicles(int count)
        {
            
            var filtreCar=this.vehicles.GetAll().Where(x=>x.IsDamaged==true).OrderBy(x=>x.Brand).ThenBy(x=>x.Model).ToList();
            
            if(count>filtreCar.Count) count=filtreCar.Count;
            for (int i = 0; i < count; i++)
            {
                filtreCar[i].Recharge();
                filtreCar[i].ChangeStatus();
            }

            return string.Format(OutputMessages.RepairedVehicles, count);
        }


        public string UsersReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("*** E-Drive-Rent ***");

            foreach (var user in this.useers.GetAll().OrderByDescending(x=>x.Rating).ThenBy(x=>x.LastName).ThenBy(x=>x.FirstName))
            {
                sb.AppendLine(user.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
