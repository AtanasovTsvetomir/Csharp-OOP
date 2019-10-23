using System.Linq;
using System;

using Telephony.Contracts;
using Telephony.Exceptions;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowseable
    {
        public Smartphone()
        {

        }

        public string Browse(string url)
        {
            if (url.Any(c => Char.IsDigit(c)))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(c => Char.IsDigit(c)))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Calling... {phoneNumber}";
        }
    }
}
