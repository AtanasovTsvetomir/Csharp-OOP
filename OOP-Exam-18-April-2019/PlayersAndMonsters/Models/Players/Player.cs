using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        //private readonly ICardRepository cardRepository;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }

        public ICardRepository CardRepository { get; private set;}

        public string Username
        {
            get => this.username;
            private set
            {
                Validator.ThrowIfUsernameIsInvalid(value, ExceptionMessages.InvalidPLayerUserName);

                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            set
            {
                Validator.ThrowIfIntergerIsBelowZero(value, ExceptionMessages.InvlidPlayerHealth);

                this.health = value;
            }
        }

        public bool IsDead => this.Health <= 0;

        public void TakeDamage(int damagePoints)
        {
            Validator.ThrowIfIntergerIsBelowZero(damagePoints, ExceptionMessages.InvalidDamagePoints);

            int newHealth = this.Health - damagePoints;

            if (newHealth < 0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health = newHealth;
            }
        }

        public override string ToString()
        {
            return string.Format(
                ConstantMessages.PlayerReportInfo,
                this.Username,
                this.Health,
                this.CardRepository.Count);
        }
    }
}
