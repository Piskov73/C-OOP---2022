namespace Telephony.Exception
{
    using System;
    public class InvalidBrowse : Exception
    {
        private const string INVALID_BROWSE = "Invalid URL!";
        public InvalidBrowse() : base(INVALID_BROWSE)
        {

        }
        public InvalidBrowse(string message) : base(message)
        {
            
        }

    }
}
