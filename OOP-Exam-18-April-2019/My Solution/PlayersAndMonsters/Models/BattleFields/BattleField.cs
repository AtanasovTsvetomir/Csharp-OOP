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
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer is Beginner)
            {
                attackPlayer.Health += 40;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            if (enemyPlayer is Beginner)
            {
                enemyPlayer.Health += 40;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            var attackPlayerBonusHealth = attackPlayer
                .CardRepository
                .Cards
                .Sum(c => c.HealthPoints);

            attackPlayer.Health += attackPlayerBonusHealth;

            var enemyPlayerBonusHealth = enemyPlayer
                .CardRepository
                .Cards
                .Sum(c => c.HealthPoints);

            enemyPlayer.Health += enemyPlayerBonusHealth;

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
    }
}
