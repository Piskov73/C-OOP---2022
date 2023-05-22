namespace Telephony.Models
{
    using System;
    using System.Linq;

    using Interfaces;
    using Exception;

    public class Smartphone : ISmartphone
    {

        public string Call(string phoneNumber)
        {
            if (!InvalidPhoneNumber(phoneNumber))
                throw new InvalidPhoneNumber();
            return $"Calling... {phoneNumber}";
        }
        public string Browse(string url)
        {
            if (!InvalidBrowse(url))
                throw new InvalidBrowse();

            return $"Browsing: {url}!";
        }

        private bool InvalidPhoneNumber(string phoneNumber) => phoneNumber.All(ch => char.IsDigit(ch));
        private bool InvalidBrowse(string url) => url.All(ch => !char.IsDigit(ch));
    }
}
