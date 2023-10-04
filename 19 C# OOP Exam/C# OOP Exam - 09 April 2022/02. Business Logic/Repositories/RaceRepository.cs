using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races=new List<IRace>();
        public IReadOnlyCollection<IRace> Models => this.races.AsReadOnly();

        public void Add(IRace model)
        {
            this.races.Add(model);
        }

        public IRace FindByName(string name)
        {
            return this.races.FirstOrDefault(r=>r.RaceName==name);
        }

        public bool Remove(IRace model)
        {
            return races.Remove(model);
        }
    }
}
