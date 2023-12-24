﻿using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
    public class ClimberRepository : IRepository<IClimber>
    {
        private HashSet<IClimber> all;
        public ClimberRepository()
        {
            this.all=new HashSet<IClimber>();
        }
        public IReadOnlyCollection<IClimber> All => this.all.ToList().AsReadOnly();

        public void Add(IClimber model)
        {
            this.all.Add(model);
        }

        public IClimber Get(string name)
        {
            return this.all.FirstOrDefault(n => n.Name == name);
        }
    }
}
