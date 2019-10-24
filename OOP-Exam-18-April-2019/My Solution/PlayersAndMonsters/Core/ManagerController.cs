namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private readonly ICardRepository cardRepository;
        private readonly IPlayerRepository playerRepository;

        public ManagerController(ICardRepository cardRepository, IPlayerRepository playerRepository)
        {
            this.cardRepository = cardRepository;
            this.playerRepository = playerRepository;
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = null;

            if (type == "Beginner")
            {
                player = new Beginner(cardRepository, username);
            }
            else if (type == "Advanced")
            {
                player = new Advanced(cardRepository, username);
            }

            playerRepository.Add(player);

            return $"Successfully added player of type {player.GetType().Name} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            ICard card = null;

            if (type == "Trap")
            {
                card = new TrapCard(name);
            }
            else if (type == "Magic")
            {
                card = new MagicCard(name);
            }

            this.cardRepository.Add(card);

            return $"Successfully added card of type {card.GetType().Name}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = playerRepository.Find(username);
            var card = cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return $"Successfully added card: {username} to user: {cardName}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
