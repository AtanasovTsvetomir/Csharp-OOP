using System.Collections.Generic;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

using System.Linq;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            var civilPlayer = civilPlayers.First();
            
            IGun mainPlayerGun = mainPlayer.GunRepository.Models.First();
            IGun civilPlayerGun = civilPlayer.GunRepository.Models.First();

            while (true)
            {
                if (mainPlayer.GunRepository.Models.Count <= 0)
                {
                    break;
                }

                if (civilPlayers.Count <= 0)
                {
                    break;
                }

                civilPlayer.TakeLifePoints(mainPlayerGun.BulletsPerBarrel);

                if (mainPlayerGun.TotalBullets <= 0)
                {
                    mainPlayerGun = mainPlayer.GunRepository.Models.First();
                }

                if (!civilPlayer.IsAlive)
                {
                    civilPlayer = civilPlayers.First();
                }
            }

            while (true)
            {
                mainPlayer.TakeLifePoints(civilPlayerGun.BulletsPerBarrel);

                if (civilPlayerGun.TotalBullets <= 0)
                {
                    civilPlayerGun = civilPlayer.GunRepository.Models.First();
                }

                if (civilPlayer.GunRepository.Models.Count <= 0)
                {
                    civilPlayer = civilPlayers.First();
                }

                if (mainPlayer.LifePoints <= 0)
                {
                    break;
                }
            }
        }
    }
}
