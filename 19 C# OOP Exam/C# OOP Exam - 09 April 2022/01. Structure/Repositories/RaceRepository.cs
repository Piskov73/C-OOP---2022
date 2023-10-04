using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;
        private RaceRepository()
        {
            this.races = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => this.races.AsReadOnly();

        public void Add(IRace race)
        {
            this.races.Add(race);
        }

        public IRace FindByName(string raceName)
        {
            return this.races.Find(r => r.RaceName == raceName);
        }

        public bool Remove(IRace model)
        {
            return this.races.Remove(model);
        }
    }
}
