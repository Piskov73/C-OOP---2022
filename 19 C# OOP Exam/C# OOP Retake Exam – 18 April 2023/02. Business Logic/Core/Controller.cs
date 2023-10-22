using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        //        • users – UserRepository
        //• vehicles – VehicleRepository
        //• routes – RouteRepository

        private UserRepository users;
        private VehicleRepository vehicles;
        private RouteRepository routes;

        public Controller()
        {
            this.users = new UserRepository();
            this.vehicles = new VehicleRepository();
            this.routes = new RouteRepository();
        }


        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            var user = this.users.FindById(drivingLicenseNumber);
            if (user != null)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }

            user = new User(firstName, lastName, drivingLicenseNumber);

            this.users.AddModel(user);

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

            if (this.vehicles.GetAll().Any(x => x.LicensePlateNumber == licensePlateNumber))
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }
            this.vehicles.AddModel(vehicle);


            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            int id = this.routes.GetAll().Count + 1;
            var routeExtraktion = this.routes.GetAll().FirstOrDefault(x => x.StartPoint == startPoint && x.EndPoint == endPoint);

            if (routeExtraktion != null)
            {
                if (routeExtraktion.Length == length)
                {
                    return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
                }
                else if (routeExtraktion.Length < length)
                {
                    return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
                }
                else if (routeExtraktion.Length > length)
                {
                    routeExtraktion.LockRoute();
                }



            }

            var rotre = new Route(startPoint, endPoint, length, id);

            this.routes.AddModel(rotre);

            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
        }


        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            var user = this.users.FindById(drivingLicenseNumber);
            if (user.IsBlocked)
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }
            var vehcle = this.vehicles.FindById(licensePlateNumber);

            if (vehcle.IsDamaged)
            {
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }

            var route = this.routes.FindById(routeId);

            if (route.IsLocked)
            {
                return string.Format(OutputMessages.RouteLocked, routeId);
            }

            vehcle.Drive(route.Length);

            if (isAccidentHappened)
            {
                vehcle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehcle.ToString();

        }


        public string RepairVehicles(int count)
        {
            var vehiclesExtrating=this.vehicles.GetAll().Where(x=>x.IsDamaged).OrderBy(x=>x.Brand).ThenBy(x=>x.Model).ToList();

            if (count > vehiclesExtrating.Count)
            {
                count=vehiclesExtrating.Count;
            }

            var vehiclesRepaier=vehiclesExtrating.ToArray().Take(count);

            foreach (var vehicle in vehiclesRepaier)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }

            return string.Format(OutputMessages.RepairedVehicles,count);
        }
        
        

        public string UsersReport()
        {
          var allUsers=this.users.GetAll().OrderByDescending(x=>x.Rating).ThenBy(x=>x.LastName).ThenBy(x=>x.FirstName).ToArray();

            StringBuilder sb=new StringBuilder();

            sb.AppendLine("*** E-Drive-Rent ***");

            foreach (var user in allUsers)
            {
                sb.AppendLine(user.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
