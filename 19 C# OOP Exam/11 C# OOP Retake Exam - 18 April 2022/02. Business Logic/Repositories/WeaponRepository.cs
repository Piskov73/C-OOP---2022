﻿using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;

        public WeaponRepository() { this.models = new List<IWeapon>(); }

        public IReadOnlyCollection<IWeapon> Models => throw new System.NotImplementedException();

        public void Add(IWeapon model)
        {
            this.models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IWeapon model)
        {
            return this.models.Remove(model);
        }
    }
}
