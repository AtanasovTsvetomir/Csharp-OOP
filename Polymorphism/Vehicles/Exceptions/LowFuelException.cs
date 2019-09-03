using System;

namespace Vehicles.Exceptions
{
    public class LowFuelException : Exception
    {
        public LowFuelException(string message) 
            : base(message)
        {

        }
    }
}
