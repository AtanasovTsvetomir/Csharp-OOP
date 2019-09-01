using System;
using System.Text;
using ClassBoxData.Exceptions;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double widht;
        private double height;

        public Box(double length, double widht, double height)
        {
            this.Length = length;
            this.Widht = widht;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionsMessages.LengthZeroOrNegativeException);
                }

                this.length = value;
            }
        }

        public double Widht
        {
            get
            {
                return this.widht;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionsMessages.WidthZeroOrNegativeException);
                }

                this.widht = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionsMessages.HeightZeroOrNegativeException);
                }

                this.height = value;
            }
        }

        public double LateralSurfaceArea()
        {
            double lateralSurfaceArea = (2 * this.Length * this.Height) +
                (2 * this.Widht * this.Height);

            return lateralSurfaceArea;
        }

        public double SurfaceArea()
        {
            double surfaceArea = (2 * this.Length * this.Widht) +
                LateralSurfaceArea();

            return surfaceArea;
        }

        public double Volume()
        {
            double volume = this.Length * this.Height * this.Widht;

            return volume;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result
                .AppendLine($"Surface Area - {this.SurfaceArea():f2}")
                .AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}")
                .AppendLine($"Volume - {this.Volume():f2}");

            return result.ToString().TrimEnd();
        }
    }
}
