namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;

        public Rifle(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            int shoot = 5;

            this.BulletsPerBarrel -= shoot;

            if (BulletsPerBarrel <= 0)
            {
                this.TotalBullets -= 50;
                this.BulletsPerBarrel += 50;
            }

            return shoot;
        }
    }
}
