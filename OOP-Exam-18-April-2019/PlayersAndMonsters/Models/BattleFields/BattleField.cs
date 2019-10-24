using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Linq;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ExceptionMessages.DeadPlayer);
            }

            if (attackPlayer is Beginner)
            {
                BoostBeginnerPlayer(attackPlayer);
            }

            if (enemyPlayer is Beginner)
            {
                BoostBeginnerPlayer(enemyPlayer);
            }

            BoostPlayerHealthPoints(attackPlayer);
            BoostPlayerHealthPoints(enemyPlayer);

            var enemyPlayerDamage = enemyPlayer
                 .CardRepository
                 .Cards
                 .Sum(c => c.DamagePoints);

            var attackerPlayerDamage = attackPlayer
                 .CardRepository
                 .Cards
                 .Sum(c => c.DamagePoints);

            while (true)
            {

                enemyPlayer.TakeDamage(attackerPlayerDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayerDamage);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private void BoostPlayerHealthPoints(IPlayer player)
        {
            var playerBonusHealth = player
                            .CardRepository
                            .Cards
                            .Sum(c => c.HealthPoints);

            player.Health += playerBonusHealth;
        }

        private void BoostBeginnerPlayer(IPlayer player)
        {
            player.Health += 40;

            foreach (var card in player.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }
    }
}
