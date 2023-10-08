using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> teams;
        public TeamRepository()
        {
            this.teams = new List<ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models => this.teams.AsReadOnly();

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
            return this.teams.FirstOrDefault(team => team.Name == name);
        }

        public bool RemoveModel(string name)
        {
            return this.teams.Remove(this.teams.Find(team => team.Name == name));
        }
    }
}
