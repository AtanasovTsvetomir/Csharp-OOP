using System;
using Ferrari.Contracts;
using Ferrari.Models;

namespace Ferrari
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string driverName = Console.ReadLine();

            IFerrari car = new Car(driverName);

            Console.WriteLine(car.ToString());
        }
    }
}
