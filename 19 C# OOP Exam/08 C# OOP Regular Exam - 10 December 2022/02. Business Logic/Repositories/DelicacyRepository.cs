using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> models;
        public DelicacyRepository()
        {
            this.models = new List<IDelicacy>();
        }
        public IReadOnlyCollection<IDelicacy> Models =>this.models.AsReadOnly();

        public void AddModel(IDelicacy model)
        {
           this.models.Add(model);
        }
    }
}
