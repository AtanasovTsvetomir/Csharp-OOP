﻿using System.Collections.Generic;
using System.Linq;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly List<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<IMotorcycle>();
        }

        public void Add(IMotorcycle model)
        => this.motorcycles.Add(model);

        public IReadOnlyCollection<IMotorcycle> GetAll()
        => this.motorcycles.ToList();

        public IMotorcycle GetByName(string name)
        => this.motorcycles.FirstOrDefault(x => x.Model == name);

        public bool Remove(IMotorcycle model)
        => this.motorcycles.Remove(model);
    }
}
