using PlayersAndMonsters.Elfs;
using PlayersAndMonsters.Knights;
using PlayersAndMonsters.Wizards;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            MuseElf museElf = new MuseElf("Asd", 20);

            System.Console.WriteLine(museElf);
        }
    }
}