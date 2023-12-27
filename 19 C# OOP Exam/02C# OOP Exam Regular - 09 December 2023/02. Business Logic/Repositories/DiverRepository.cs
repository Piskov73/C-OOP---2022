using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Repositories
{
    public class DiverRepository : IRepository<IDiver>
    {
        private HashSet<IDiver> models;
        public DiverRepository()
        { 
            this.models = new HashSet<IDiver>();
        }
        public IReadOnlyCollection<IDiver> Models => this.models.ToList().AsReadOnly();

        public void AddModel(IDiver model)
        {
           this.models.Add(model);
        }

        public IDiver GetModel(string name)
        {
            return models.FirstOrDefault(n => n.Name == name);
        }
    }
}
