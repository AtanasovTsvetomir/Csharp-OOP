using MortalEngines.IO;
using MortalEngines.Core;
using MortalEngines.IO.Contracts;
using MortalEngines.Core.Contracts;
using MortalEngines.Core.Factories;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            IPilotFactory pilotFactory = new PilotFactory();
            IMachinesManager machinesManager = new MachinesManager(pilotFactory);

            ICommandInterpreter commandInterpreter = new CommandInterpreter(machinesManager);
            IWriter writer = new Writer();

            IEngine engine = new Engine(commandInterpreter, writer);
            engine.Run();
        }
    }
}