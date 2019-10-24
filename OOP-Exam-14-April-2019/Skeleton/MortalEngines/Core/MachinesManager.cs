namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;
        

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            IPilot pilot = new Pilot(name);

            if (!pilots.Any(p => p.Name==name))
            {
                pilots.Add(pilot);

                return $"Pilot {name} hired";
            }
            else
            {
                return $"Pilot {name} is hired already";
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            ITank tank = new Tank(name, attackPoints, defensePoints);

            if (!machines.Any(t => t.Name == name))
            {
                machines.Add(tank);

                return $"Tank {name} manufactured - attack: {attackPoints}; defense: {defensePoints}";
            }
            else
            {
                return $"Machine {name} is manufactured already";
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            IFighter fighter = new Fighter(name, attackPoints, defensePoints);

            string result = string.Empty;

            if (!machines.Any(t => t.Name == name))
            {
                machines.Add(fighter);

                result = string.Format(
                    OutputMessages.FighterManufactured,
                    name,
                    fighter.AttackPoints,
                    fighter.DefensePoints,
                    fighter.AggressiveMode == true ? "ON" : "OFF"
                    );
            }
            else
            {
                result = string.Format(
                    OutputMessages.MachineExists,
                    name);
            }

            return result;
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = this.pilots
                .FirstOrDefault(p => p.Name == selectedPilotName);

            if (pilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            IMachine machine = this.machines
                .FirstOrDefault(m => m.Name == selectedMachineName);

            if (machine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            if (machine.Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackMachine = this.machines
                .FirstOrDefault(m => m.Name == attackingMachineName);

            if (attackMachine == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            IMachine defendingMachine = this.machines
                .FirstOrDefault(d => d.Name == defendingMachineName);

            if (defendingMachine == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            if (attackMachine.HealthPoints <= 0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }

            if (defendingMachine.HealthPoints <= 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }

            attackMachine.Attack(defendingMachine);

            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defendingMachine.HealthPoints:f2}";
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilotToReport = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);

            if (pilotToReport == null)
            {
                return $"Pilot {pilotReporting} could not be found";
            }

            return pilotToReport.Report();
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = this.machines
                .FirstOrDefault(m => m.Name == machineName);

            if (machine == null)
            {
                return $"Machine {machineName} could not be found";
            }

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IMachine machine = this.machines
                .FirstOrDefault(m => m.Name == fighterName);

            if (machine == null)
            {
                return $"Machine {fighterName} could not be found";
            }

            IFighter fighter = (IFighter)machine;

            fighter.ToggleAggressiveMode();

            return $"Fighter {fighterName} toggled aggressive mode";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            IMachine machine = this.machines
                .FirstOrDefault(m => m.Name == tankName);

            if (machine == null)
            {
                return $"Machine {tankName} could not be found";
            }

            ITank tank = (ITank)machine;

            tank.ToggleDefenseMode();

            return $"Tank {tankName} toggled defense mode";
        }
    }
}