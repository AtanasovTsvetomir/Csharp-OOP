﻿namespace NeedForSpeed.Cars
{
    public class Car : Vehicle
    {
        private const double DefaultFuelConsumtion = 3;

        public Car(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption => DefaultFuelConsumtion;
    }
}