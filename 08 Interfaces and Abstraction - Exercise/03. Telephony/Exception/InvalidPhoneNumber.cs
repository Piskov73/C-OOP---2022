namespace Telephony.Exception
{
    using System;
    public class InvalidPhoneNumber : Exception
    {
        private const string INVALID_NUMBERE = "Invalid number!";
        public InvalidPhoneNumber():base(INVALID_NUMBERE) 
        {

        }
        public InvalidPhoneNumber(string message):base(message)
        {

        }

    }
}
