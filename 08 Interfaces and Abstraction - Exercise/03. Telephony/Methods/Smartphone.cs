
namespace Telephony.Methods
{
    using System.Linq;

    using Exception;
    using Interface;

    public class Smartphone : ISmartphone
    {
       

        public string Call(string phoneNumber)
        {
            if(!this.InvalidPhone(phoneNumber))
            {
                throw new InvalidPhoneNumber();
            }
            return $"Calling... {phoneNumber}";
        }

        public string Browse(string url)
        {
            if(!this.InvalidURL(url))
            {
                throw new InvalidBrowsingURL();
            }
            return $"Browsing: {url}!";
        }

        private bool InvalidPhone(string phoneNumber) =>phoneNumber.All(ch=>char.IsDigit(ch));
        private bool InvalidURL(string url)=>url.All(ch=>!char.IsDigit(ch));
    }
}
