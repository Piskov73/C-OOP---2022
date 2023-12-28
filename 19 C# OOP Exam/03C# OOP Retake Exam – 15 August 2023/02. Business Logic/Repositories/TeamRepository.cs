using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private HashSet<ITeam> teams;
        public TeamRepository()
        {
            this.teams = new HashSet<ITeam>();
        }
        public IReadOnlyCollection<ITeam> Models => this.teams.ToList().AsReadOnly();

        public void AddModel(ITeam model)
        {
            this.teams.Add(model);
        }

        public bool ExistsModel(string name)
        {
            return this.teams.Any(teams => teams.Name == name);
        }

        public ITeam GetModel(string name)
        {
           return this.teams.FirstOrDefault(teams => teams.Name == name);   
        }

        public bool RemoveModel(string name)
        {
           return this.teams.Remove(GetModel(name));
        }
    }
}
