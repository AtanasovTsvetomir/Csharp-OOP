using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private GangNeighbourhood gangNeighbourhood;
        private ICollection<IPlayer> civilPlayers;
        private GunRepository gunRepository;
        private MainPlayer mainPlayer;

        public Controller()
        {
            this.gangNeighbourhood = new GangNeighbourhood();
            this.mainPlayer = new MainPlayer();
            this.gunRepository = new GunRepository();
            this.civilPlayers = new List<IPlayer>();
        }

        public string AddGun(string type, string name)
        {
            if (type == "Pistol")
            {
                IGun gun = new Pistol(name);

                gunRepository.Add(gun);

                return $"Successfully added {name} of type: {type}";
            }
            else if (type == "Rifle")
            {
                IGun gun = new Rifle(name);

                gunRepository.Add(gun);

                return $"Successfully added {name} of type: {type}";
            }
            else
            {
                return "Invalid gun type!";
            }
        }

        public string AddGunToPlayer(string name)
        {
            if (gunRepository.Models.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            var gun = gunRepository.Models.First();

            if (name == "Vercetti")
            {
                mainPlayer.GunRepository.Add(gun);

                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            if (!civilPlayers.Any(n=>n.Name == name))
            {
                return "Civil player with that name doesn't exists!";
            }

            return $"Successfully added {gun.Name} to the Civil Player: {name}";
        }

        public string AddPlayer(string name)
        {
            CivilPlayer player = new CivilPlayer(name);

            civilPlayers.Add(player);

            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            int civilPlayersCount = civilPlayers.Count;

            gangNeighbourhood.Action(mainPlayer, civilPlayers);

            int deadCivilPlayers = civilPlayers.Count - civilPlayersCount;

            StringBuilder result = new StringBuilder();

            if (mainPlayer.LifePoints == 100 && (civilPlayers.Any(p => p.LifePoints == 50) || civilPlayers.Count == civilPlayersCount))
            {
               return "Everything is okay!";
            }

            if (mainPlayer.LifePoints != 100 && civilPlayers.Any(p => p.LifePoints != 50))
            {
                result.AppendLine("A fight happened:")
                    .AppendLine($"Tommy live points: {mainPlayer.LifePoints}!")
                    .AppendLine($"Tommy has killed: {deadCivilPlayers} players!")
                    .AppendLine($"Left Civil Players: {civilPlayersCount}!");
            }

            return result.ToString().TrimEnd();
        }
    }
}
