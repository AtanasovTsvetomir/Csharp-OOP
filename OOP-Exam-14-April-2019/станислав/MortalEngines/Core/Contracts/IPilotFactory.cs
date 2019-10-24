using MortalEngines.Entities.Contracts;

namespace MortalEngines.Core.Contracts
{
    public interface IPilotFactory
    {
        IPilot CreatePilot(string name);
    }
}
