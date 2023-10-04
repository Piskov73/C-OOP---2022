namespace Formula1.Repositories
{
    using System.Collections.Generic;

    using Models.Contracts;
    using Repositories.Contracts;
    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> pilots;
        public PilotRepository()
        {
            this.pilots= new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => this.pilots.AsReadOnly();

        public void Add(IPilot pilot)
        {
            this.pilots.Add(pilot); 
        }

        public IPilot FindByName(string name)
        {
            return this.pilots.Find(p =>p.FullName == name);
        }

        public bool Remove(IPilot pilot)
        {
            return this.pilots.Remove(pilot);
        }
    }
    
}
