namespace Telephony.Models
{
    using System.Linq;

    using Interfaces;
    using Exception;

    public class StationaryPhone : IStationaryPhone
    {
        public string Call(string phoneNumber)
        {
            if (!InvalidPhoneNumber(phoneNumber))
                throw new InvalidPhoneNumber();

            return $"Dialing... {phoneNumber}";
        }
        private bool InvalidPhoneNumber(string phoneNumber) => phoneNumber.All(ch => char.IsDigit(ch));
    }
}
