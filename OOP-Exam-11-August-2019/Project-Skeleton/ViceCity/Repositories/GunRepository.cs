using System.Collections.Generic;
using System.Linq;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.guns.AsReadOnly();

        public void Add(IGun model)
        {
            if (!guns.Any(g => g.Name == model.Name))
            {
                guns.Add(model);
            }
        }

        public IGun Find(string name)
        {
            return guns.FirstOrDefault(n => n.Name == name);
        }

        public bool Remove(IGun model)
        {
            bool isRemoved = guns.Remove(model);

            return isRemoved;
        }
    }
}
