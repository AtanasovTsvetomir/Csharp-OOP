﻿using System;
using System.Collections.Generic;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private Dictionary<string, IPlayer> playersByName;

        public PlayerRepository()
        {
            this.playersByName = new Dictionary<string, IPlayer>();
        }

        public int Count => this.playersByName.Count;

        public IReadOnlyCollection<IPlayer> Players => playersByName.Values;

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayer);
            }

            if (this.playersByName.ContainsKey(player.Username))
            {
                throw new ArgumentException(
                    string.Format(
                    ExceptionMessages.PlayerAlreadyExist, player.Username));
            }

            this.playersByName.Add(player.Username, player);
        }

        public IPlayer Find(string username)
        {
            IPlayer player = null;

            if (this.playersByName.ContainsKey(username))
            {
                player = this.playersByName[username];
            }

            return player;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayer);
            }

            bool hasRemoved = this.playersByName.Remove(player.Username);

            return hasRemoved;
        }
    }
}