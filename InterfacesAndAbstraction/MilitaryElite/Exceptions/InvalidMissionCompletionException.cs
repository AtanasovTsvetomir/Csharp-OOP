using System;

namespace MilitaryElite.Exceptions
{
    class InvalidMissionCompletionException : Exception
    {
        public const string EXC_MESSAGE = "You cannot finish already completed mission!";
        public InvalidMissionCompletionException()
            : base(EXC_MESSAGE)
        {

        }

        public InvalidMissionCompletionException(string message) : base(message)
        {

        }
    }
}
