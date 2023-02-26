using System;
using System.Collections.Generic;
using System.Linq;
namespace _05FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> playerList;
        public Team(string name)
        {
            this.Name = name;
            playerList = new List<Player>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(MessageException.NAME_NULL_EMPTY);
                }
                name = value;
            }
        }
        public void AddPlayer(Player player)
        {
            playerList.Add(player);
        }
        public void RemovePlayer(string player)
        {
            var remuvPlayer = playerList.FirstOrDefault(x => x.Name == player);
            if (remuvPlayer == null)
            {
                
                throw new ArgumentException(string.Format(MessageException.MISSING_PLAYER,player,this.Name));
            }
            playerList.Remove(remuvPlayer);
        }
        private int Rating
        {
            get
            {
                if (playerList.Count == 0)
                {
                    return 0;
                }
                return (int)Math.Round(playerList.Select(x => x.SkillLevel).Average());
            }
                
        }

        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }

    }
}
