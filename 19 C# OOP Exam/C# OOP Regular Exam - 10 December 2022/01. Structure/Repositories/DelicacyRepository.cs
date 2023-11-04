using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> items;

        public DelicacyRepository()
        {
            this.items = new List<IDelicacy>();
        }
        public IReadOnlyCollection<IDelicacy> Models => this.items.AsReadOnly();

        public void AddModel(IDelicacy model)
        {
            this.items.Add(model);
        }
    }
}
