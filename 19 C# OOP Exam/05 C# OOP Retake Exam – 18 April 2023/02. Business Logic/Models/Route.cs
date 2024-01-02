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
            this.Length=length;
            this.RouteId = routeId;
            this.IsLocked = false;
        }
        public string StartPoint
        {
            get => startPoint;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.StartPointNull));

                startPoint = value;
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

        public int RouteId { get=>routeId;private set => routeId = value; }

        public bool IsLocked { get => isLocked; private set => isLocked = value; }

        public void LockRoute()
        {
            this.IsLocked = true;
        }
    }
}
