using Ferrari.Contracts;

namespace Ferrari.Models
{
    public class Car : IFerrari
    {
        public Car(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public string Brake()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"488-Spider/{this.Brake()}/{this.Gas()}/{this.Name}";
        }
    }
}
