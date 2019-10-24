using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player
    {
        private const int INITIAL_ADVANCED_PLAYER_HEALTH = 250;

        public Advanced(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, INITIAL_ADVANCED_PLAYER_HEALTH)
        {
        }
    }
}
