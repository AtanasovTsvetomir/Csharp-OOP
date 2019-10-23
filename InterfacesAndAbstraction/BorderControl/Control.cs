namespace BorderControl
{
    public class Control : ICitizen, IRobot, IPet
    {
        public Control(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }

        public Control(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }

        public string Model { get; set; }

        public string Birthday { get; set; }

    }
}
