using System;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private int horsePower;

        private const double InitialCubicCentimeters = 450;

        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, InitialCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (true)
                {
                    if (value < 70 || value > 100)
                    {
                        throw new ArgumentException($"Invalid horse power: {value}.");
                    }
                }

                this.horsePower = value;
            }
        }
    }
}
