using MortalEngines.Common;
using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        private string name;
        private List<IMachine> machines;

        private Pilot()
        {
            this.machines = new List<IMachine>();
        }

        public Pilot(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPilotName);
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidMachine);
            }

            machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.Name} - {machines.Count} machines");

            foreach (var machine in machines)
            {
                result.AppendLine(machine.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
