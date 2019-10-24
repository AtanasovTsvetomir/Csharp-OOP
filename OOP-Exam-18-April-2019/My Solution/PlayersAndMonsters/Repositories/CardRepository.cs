using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count => this.Cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card is null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            bool ifCardExist = cards.Any(c => c.Name == card.Name);

            if (ifCardExist)
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            cards.Add(card);
        }

        public ICard Find(string name)
        {
            ICard card = this.cards.FirstOrDefault(c => c.Name == name);

            if (name is null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            return card;
        }

        public bool Remove(ICard card)
        {
            if (card is null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            bool hasRemoved = this.cards.Remove(card);

            return hasRemoved;
        }
    }
}
