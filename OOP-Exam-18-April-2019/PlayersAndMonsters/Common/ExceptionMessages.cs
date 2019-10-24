namespace PlayersAndMonsters.Common
{
    public static class ExceptionMessages
    {
        public const string InvalidPLayerUserName =
            "Player's username cannot be null or an empty string.";

        public const string InvlidPlayerHealth =
            "Player's health bonus cannot be less than zero.";

        public const string InvalidDamagePoints =
            "Damage points cannot be less than zero.";

        public const string InvalidCardName =
            "Card's name cannot be null or an empty string.";

        public const string InvalidCardDamagePoints =
            "Card's damage points cannot be less than zero.";

        public const string InvalidCardHealthPoints =
            "Card's HP cannot be less than zero.";

        public const string DeadPlayer =
            "Player is dead!";

        public const string InvalidCard =
            "Card cannot be null!";

        public const string CardAlreadyExist =
            "Card {0} already exists!";

        public const string InvalidPlayer =
            "Player cannot be null";

        public const string PlayerAlreadyExist =
            "Player {0} already exists!";
    }
}
