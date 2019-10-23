namespace BorderControl
{
    public interface ICitizen : IIdentifiable, IBirthable
    {
        string Name { get; set; }
        int Age { get; set; }
    }
}
