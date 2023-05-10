namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private HashSet<Player> players;

        private Team()
        {
            this.players = new HashSet<Player>();
        }
        public Team(string name) : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(MessageExceptions.NAME_NOT_BI_EMPTY);
                name = value;
            }
        }

        
        public void Add(Player player)
        {
            this.players.Add(player);
        }
        public void Remove(string namePlayer)
        {
            var filterPlayer = this.players.FirstOrDefault(p => p.Name == namePlayer);
            if (filterPlayer == null)
                throw new ArgumentException(string.Format(MessageExceptions.PLAYER_IS_NOT_TEAM, namePlayer, Name));
            this.players.Remove(filterPlayer);

        }
        public override string ToString()
        {
            if(this.players.Count == 0)
                return $"{Name} - 0";
            return $"{Name} - {this.players.Average(p=>p.Stats.SkillLevel):F0}";
        }

    }
}
