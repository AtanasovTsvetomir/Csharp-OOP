using System;

namespace PlayersAndMonsters.Common
{
    public static class Validator
    {
        public static void ThrowIfIntergerIsBelowZero(int value, string message)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfUsernameIsInvalid(string name, string message)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(message);
            }
        }
    }
}