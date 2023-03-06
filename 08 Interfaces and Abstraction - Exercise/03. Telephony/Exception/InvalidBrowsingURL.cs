namespace Telephony.Exception
{
    using System;

    public class InvalidBrowsingURL : Exception
    {
        private const string INVALID_URL = "Invalid URL!";
        public InvalidBrowsingURL(): base(INVALID_URL)
        { 

        }
        public InvalidBrowsingURL(string message): base(message)
        {

        }

    }
}
