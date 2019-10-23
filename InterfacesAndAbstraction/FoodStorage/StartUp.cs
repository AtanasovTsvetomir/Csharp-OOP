using FoodStorage.Core;
using System;

namespace FoodStorage
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
