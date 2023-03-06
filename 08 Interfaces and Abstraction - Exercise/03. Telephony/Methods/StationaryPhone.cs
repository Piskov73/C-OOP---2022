
namespace Telephony.Methods
{
    using System;
    using System.Linq;

    using Exception;
    using Interface;


    public class StationaryPhone : IStationaryPhone
    {
        public string Call(string phoneNumber)
        {
            if (!this.InvalidNumber(phoneNumber))
            {
                throw new InvalidPhoneNumber();
            }
            return $"Dialing... {phoneNumber}";
        }

      

        private bool InvalidNumber(string phoneNumber) => phoneNumber.All(ch => (char.IsDigit(ch)));
    }
}
