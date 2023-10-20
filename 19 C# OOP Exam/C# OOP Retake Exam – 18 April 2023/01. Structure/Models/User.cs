using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private double rating;
        private string drivingLicenseNumber;
        private bool isBlocked;

        public User(string firstName, string lastName, string drivingLicenseNumber)
        { 
            FirstName=firstName;
            LastName=lastName;
            DrivingLicenseNumber=drivingLicenseNumber;
            this.rating=0;
            this.isBlocked = false;

        }
        public string FirstName
        {
            get { return firstName; }
           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.FirstNameNull));
                }
                firstName = value; 
            }
        }



        public string LastName
        {
            get { return lastName; }
           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.LastNameNull));
                }
                lastName = value;
            }
        }


        public double Rating { get => rating; private set => rating = value; }


        public string DrivingLicenseNumber
        {
            get { return drivingLicenseNumber; }
           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.DrivingLicenseRequired));
                }
                drivingLicenseNumber = value; 
            }
        }


        public bool IsBlocked { get => isBlocked;private set=>isBlocked = value; }

        public void DecreaseRating()
        {
            this.rating -= 2;
            if (this.rating <= 0)
            {
                this.rating = 0;
                this.isBlocked = true;
            }
        }

        public void IncreaseRating()
        {
            this.rating += 0.5;
            if (this.rating >10)
            {
                this.rating=10;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} Driving license: {DrivingLicenseNumber} Rating: {Rating}";
        }
    }
}
