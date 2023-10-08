using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> players;

        public PlayerRepository()
        { 
            this.players = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => this.players.AsReadOnly();

        public void AddModel(IPlayer model)
        {
          this.players.Add(model);
        }

        public bool RemoveModel(string name)
        {
            return this.players.Remove(this.players.Find(p => p.Name == name));
        }
        public bool ExistsModel(string name)
        {
            return this.players.Any(p => p.Name == name);
        }

        public IPlayer GetModel(string name)
        {
           return this.players.FirstOrDefault(p => p.Name == name);
        }

       
    }
}
