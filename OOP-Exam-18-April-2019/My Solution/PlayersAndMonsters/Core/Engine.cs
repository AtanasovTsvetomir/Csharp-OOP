using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IManagerController managerController;

        public Engine(IManagerController managerController)
        {
            this.managerController = managerController;
        }

        public void Run()
        {
            string commands = Console.ReadLine();

            while (true)
            {
                string[] Args = commands
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = Args[0];

                if (command == "Exit")
                {
                    break;
                }

                string result = string.Empty;
                string cardName = string.Empty;
           
                switch (command)
                {
                    case "AddPlayer":

                        string playerType = Args[1];
                        string playerUsername = Args[2];

                        result = managerController.AddPlayer(playerType, playerUsername);

                        break;
                    case "AddCard":

                        string cardType = Args[1];
                        cardName = Args[2];

                        result = managerController.AddCard(cardType, cardName);

                        break;
                    case "AddPlayerCard":

                        string username = Args[1];
                        cardName = Args[2];

                        result = managerController.AddPlayerCard(username, cardName);

                        break;
                    case "Fight":

                        break;
                    case "Report":

                        break;
                }

                Console.WriteLine(result);

                commands = Console.ReadLine();
            }
        }
    }
}
