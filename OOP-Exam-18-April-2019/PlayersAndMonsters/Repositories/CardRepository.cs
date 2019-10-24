﻿using System;
using System.Collections.Generic;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private Dictionary<string, ICard> cardsByName;

        public CardRepository()
        {
            this.cardsByName = new Dictionary<string, ICard>();
        }

        public int Count => this.cardsByName.Count;

        public IReadOnlyCollection<ICard> Cards => this.cardsByName.Values;

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidCard);
            }

            if (this.cardsByName.ContainsKey(card.Name))
            {
                throw new ArgumentException(
                    string.Format(
                    ExceptionMessages.CardAlreadyExist, card.Name));
            }

            this.cardsByName.Add(card.Name, card);
        }

        public ICard Find(string name)
        {
            ICard card = null;

            if (this.cardsByName.ContainsKey(name))
            {
                card = this.cardsByName[name];
            }

            return card;
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidCard);
            }

            bool hasRemoved = this.cardsByName.Remove(card.Name);

            return hasRemoved;
        }
    }
}