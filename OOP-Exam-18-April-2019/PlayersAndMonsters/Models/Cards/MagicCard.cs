namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int INITIAL_MAGIC_CARD_DAMAGE_POINTS = 5;
        private const int INITIAL_MAGIC_CARD_HEALTH_POINTS = 80;

        public MagicCard(string name) 
            : base(name, INITIAL_MAGIC_CARD_DAMAGE_POINTS, INITIAL_MAGIC_CARD_HEALTH_POINTS)
        {
        }
    }
}
