using MortalEngines.Core.Contracts;
using System;
using System.Linq;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private IMachinesManager machinesManager;

        public Engine(IMachinesManager machinesManager)
        {
            this.machinesManager = machinesManager;
        }
        public void Run()
        {
            while (true)
            {
                string inputLine = Console.ReadLine();
                string[] args = inputLine
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = args[0];

                if (command == "Quit")
                {
                    break;
                }

                string result = string.Empty;
                string name = string.Empty;
                double attackPoints = 0.0;
                double defensePoints = 0.0;

                switch (command)
                {
                    case "HirePilot":
                        name = args[1];

                        result = this.machinesManager.HirePilot(name);
                        break;
                    case "PilotReport":
                        
                        break;
                    case "MachineReport":

                        break;
                    case "ManufactureTank":
                        name = args[1];
                        attackPoints = double.Parse(args[2]);
                        defensePoints = double.Parse(args[3]);

                        result = this.machinesManager.ManufactureTank(name, attackPoints, defensePoints);

                        break;
                    case "ToggleTankDefenseMode":

                        break;
                    case "ManufactureFighter":
                        name = args[1];
                        attackPoints = double.Parse(args[2]);
                        defensePoints = double.Parse(args[3]);

                        result = this.machinesManager.ManufactureFighter(name, attackPoints, defensePoints);

                        break;
                    case "ToggleFighterAggressiveMode":

                        break;
                    case "EngageMachine":

                        break;
                    case "AttackMachines":

                        break;
                }

                Console.WriteLine(result);
            }
        }
    }
}
