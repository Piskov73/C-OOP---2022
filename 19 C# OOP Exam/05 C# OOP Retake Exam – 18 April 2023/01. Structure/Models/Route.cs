namespace EDriveRent.Models
{
    using Contracts;
    using EDriveRent.Utilities.Messages;
    using System;

    public class Route : IRoute
    {
        private string startPoint;
        private string endPoint;
        private double length;
        private int routeId;
        private bool isLocked;
        public Route(string startPoint, string endPoint, double length, int routeId)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.Length = length;
            this.routeId = routeId;
            this.isLocked = false;
        }
        public string StartPoint
        {
            get => startPoint;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.StartPointNull));

                startPoint =value;
            }
        }

        public string EndPoint
        {
            get => endPoint;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.EndPointNull));

                endPoint = value;
            }
        }

        public double Length
        {
            get => length;
            private set
            {
                if(value<1)
                    throw new ArgumentException(string.Format(ExceptionMessages.RouteLengthLessThanOne)); 
                length = value;
            }
        }

        public int RouteId => this.routeId;

        public bool IsLocked => this.IsLocked;

        public void LockRoute()
        {
            this.isLocked = !this.isLocked;
        }
    }
}
