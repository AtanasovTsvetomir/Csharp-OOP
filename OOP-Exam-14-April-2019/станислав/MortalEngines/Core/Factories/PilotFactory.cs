using System;
using System.Linq;
using System.Reflection;

using MortalEngines.Common;
using MortalEngines.Core.Contracts;
using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Models;

namespace MortalEngines.Core.Factories
{
    public class PilotFactory : IPilotFactory
    {
        public IPilot CreatePilot(string name)
        {
            Type pilotType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == nameof(Pilot));

            if (pilotType == null)
            {
                throw new ArgumentException(ExceptionMessages.PilotNullException);
            }

            IPilot pilot = (IPilot)Activator.CreateInstance(pilotType, name);

            return pilot;
        }
    }
}
