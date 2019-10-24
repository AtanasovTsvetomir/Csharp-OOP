using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player
    {
        private const int INITIAL_BEGINNER_PLAYER_HEALTH = 50;

        public Beginner(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, INITIAL_BEGINNER_PLAYER_HEALTH)
        {
        }
    }
}
