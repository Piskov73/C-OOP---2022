using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> teams;

        private TeamRepository()
        {
            this.teams=new List<ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models => this.teams.AsReadOnly();


        public void AddModel(ITeam model)
        {
            this.teams.Add(model);
        }

        public bool ExistsModel(string name)
        {
           return this.teams.Any(t=>t.Name == name);    
        }

        public ITeam GetModel(string name)
        {
           return this.teams.Find(t=>t.Name == name);
        }

        public bool RemoveModel(string name)
        {
            var team=this.teams.Find(t=> t.Name == name);
            return this.teams.Remove(team);
        }
    }
}
