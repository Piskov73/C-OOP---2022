namespace EDriveRent.Models
{
    using Contracts;
    using EDriveRent.Utilities.Messages;
    using System;

    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private double rating;
        private string drivingLicenseNumber;
        private bool isBlocked;
        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DrivingLicenseNumber = drivingLicenseNumber;
            this.rating = 0;
            this.isBlocked = false;
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

        public double Rating => this.rating;

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

        public bool IsBlocked => this.isBlocked;

        public void DecreaseRating()
        {
            this.rating -= 2;

            if(this.rating < 0)
            {
                this.rating = 0;
                this.isBlocked = true;

            }
        }

        public void IncreaseRating()
        {
            this.rating += 0.5;

            if (this.rating > 10)
                this.rating = 10;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} Driving license: {drivingLicenseNumber} Rating: {Rating}";
        }
    }
}
