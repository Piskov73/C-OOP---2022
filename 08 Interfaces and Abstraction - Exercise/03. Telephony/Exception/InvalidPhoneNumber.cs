namespace Telephony.Exception
{
    using System;
    public class InvalidPhoneNumber : Exception
    {
        private const string INVALID_NUMBER = "Invalid number!";
        public InvalidPhoneNumber() : base(INVALID_NUMBER)
        {
            
        }
        public InvalidPhoneNumber(string message) : base(message)
        {
            
        }
    }
}
