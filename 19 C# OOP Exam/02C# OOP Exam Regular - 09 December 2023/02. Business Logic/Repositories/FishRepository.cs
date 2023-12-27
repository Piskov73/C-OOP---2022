using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Repositories
{
    public class FishRepository : IRepository<IFish>
    {
        private HashSet<IFish> models;
        public FishRepository()
        { 
            this.models=new HashSet<IFish>();
        }
        public IReadOnlyCollection<IFish> Models => this.models.ToList().AsReadOnly();

        public void AddModel(IFish model)
        {
           this.models.Add(model);
        }

        public IFish GetModel(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }
    }
}
