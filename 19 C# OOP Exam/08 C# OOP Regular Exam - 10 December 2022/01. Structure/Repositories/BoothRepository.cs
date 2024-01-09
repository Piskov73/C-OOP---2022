using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        private List<IBooth> models;
        public BoothRepository()
        {
            this.models=new List<IBooth>();
        }
        public IReadOnlyCollection<IBooth> Models =>this.models.AsReadOnly();

        public void AddModel(IBooth model)
        {
            this.models.Add(model);
        }
    }
}
