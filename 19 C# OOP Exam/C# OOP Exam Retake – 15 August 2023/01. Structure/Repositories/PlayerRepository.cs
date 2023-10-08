using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> players;
        private PlayerRepository() 
        {
            this.players= new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => this.players.AsReadOnly();

        public void AddModel(IPlayer model)
        {
           players.Add(model);
        }
        public bool RemoveModel(string name)
        {
            var prayer=players.Find(x => x.Name == name);
            return players.Remove(prayer);
        }
        public bool ExistsModel(string name)
        {
           return players.Any(p=>p.Name == name);
        }

        public IPlayer GetModel(string name)
        {
            return players.Find(x=>x.Name == name);
        }

     
    }
}
