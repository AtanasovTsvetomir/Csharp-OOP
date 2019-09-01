using System;

using FootbalTeamGenerator.Core;

namespace FootbalTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
