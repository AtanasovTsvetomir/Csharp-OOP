using System.Text;

namespace Cars
{
    public class Tesla : Car , IElectricCar
    {
        public int Battery { get; set; }

        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Color} Tesla {Model} with {Battery} Batteries");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
