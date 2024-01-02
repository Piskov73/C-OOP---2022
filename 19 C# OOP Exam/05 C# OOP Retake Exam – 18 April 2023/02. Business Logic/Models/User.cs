namespace EDriveRent.Models
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private string drivingLicenseNumber;
        private double rating;
        private bool isBlocked;
        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            this.FirstName = firstName;
            this.LastName=lastName;
            this.DrivingLicenseNumber = drivingLicenseNumber;
            this.Rating = 0;
            this.IsBlocked = false;
        }
        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.FirstNameNull));

                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.LastNameNull));

                lastName = value;
            }
        }

        public double Rating { get => rating; private set => rating = value; }

        public string DrivingLicenseNumber
        {
            get => drivingLicenseNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.DrivingLicenseRequired));

                drivingLicenseNumber = value;
            }
        }

        public bool IsBlocked { get => isBlocked; private set => isBlocked = value; }

        public void DecreaseRating()
        {
            Rating -= 2;
            if (Rating < 0)
            {
                Rating = 0;
                IsBlocked=true;
            }
        }

        public void IncreaseRating()
        {
            this.Rating += 0.5;

            if(Rating>10) Rating=10;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} Driving license: {DrivingLicenseNumber} Rating: {Rating}";
        }
    }
}
