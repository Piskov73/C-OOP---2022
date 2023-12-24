using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
    public class PeakRepository : IRepository<IPeak>
    {
        private HashSet<IPeak>all;
        public PeakRepository()
        {
            this.all = new HashSet<IPeak>();
        }
        public IReadOnlyCollection<IPeak> All =>this.all.ToList().AsReadOnly();

        public void Add(IPeak model)
        {
            this.all.Add(model);
        }

        public IPeak Get(string name)
        {
            return this.all.FirstOrDefault(n => n.Name == name);
        }
    }
}
