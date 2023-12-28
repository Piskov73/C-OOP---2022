using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private HashSet<IPlayer> players;
        public PlayerRepository()
        { 
            this.players=new HashSet<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models =>this.players.ToList().AsReadOnly();

        public void AddModel(IPlayer model)
        {
            this.players.Add(model);
        }

        public bool ExistsModel(string name)
        {
            return this.players.All(x => x.Name == name);
        }

        public IPlayer GetModel(string name)
        {
            return this.players.FirstOrDefault(n => n.Name == name);
        }

        public bool RemoveModel(string name)
        {
           return this.players.Remove(GetModel(name));
        }
    }
}
