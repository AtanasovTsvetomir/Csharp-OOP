using System;

namespace Telephony.Exceptions
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string EXC_MESSAGE = "Invalid numer!";

        public InvalidPhoneNumberException()
            : base (EXC_MESSAGE)
        {

        }

        public InvalidPhoneNumberException(string message) 
            : base(message)
        {

        }
    }
}
