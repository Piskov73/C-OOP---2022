﻿using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;

        public RaceRepository() { this.models = new List<IRace>(); }

        public IReadOnlyCollection<IRace> Models => this.models.AsReadOnly();

        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public IRace FindByName(string name)
        {
            return this.models.FirstOrDefault(n=>n.RaceName==name);
        }

        public bool Remove(IRace model)
        {
            return models.Remove(model);
        }
    }
}
