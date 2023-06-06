namespace Vehicles.Exceptions
{
    using System;
    public class ExceptionInvalidVehicle : Exception
    {
        private const string InvalidVehicle = "Invalid vehicle !";
        public ExceptionInvalidVehicle() : base(InvalidVehicle)
        {

        }
        public ExceptionInvalidVehicle(string message) : base()
        {

        }
    }
}
