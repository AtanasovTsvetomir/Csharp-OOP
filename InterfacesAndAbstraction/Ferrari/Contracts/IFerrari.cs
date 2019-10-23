namespace Ferrari.Contracts
{
    public interface IFerrari
    {
        string Name { get; set; }

        string Brake();

        string Gas();
    }
}
