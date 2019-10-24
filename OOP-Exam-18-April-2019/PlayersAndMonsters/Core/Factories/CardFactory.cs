using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        private const string Suffix = "Card";

        public ICard CreateCard(string type, string name)
        {
            Type cardType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(c => c.Name == type + Suffix);

            ICard card = (ICard)Activator.CreateInstance(cardType, name);

            return card;
        }
    }
}
