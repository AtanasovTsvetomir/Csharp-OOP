namespace ViceCity.Models.Guns
{
    class Pistol : Gun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;

        public Pistol(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {

        }

        public override int Fire()
        {
            int shoot = 1;

            this.BulletsPerBarrel -= shoot;

            if (BulletsPerBarrel <= 0)
            {
                this.TotalBullets -= 10;
                this.BulletsPerBarrel += 10;
            }

            return shoot;
        }
    }
}
