
namespace Handball.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using Contracts;
    using Utilities.Messages;
    public class Team : ITeam
    {
        private string name;
        private int pointsEarned;
        private HashSet<IPlayer> players;
        private const int INCREASES_WIN_POINTS = 3;
        private const int INCREASES_DRAW_POINTS = 1;
            //increases 

        public Team(string name)
        {
            Name = name;
            PointsEarned = 0;
            players = new HashSet<IPlayer>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.TeamNameNull));
                name = value;
            }
        }

        public int PointsEarned { get => pointsEarned; private set => pointsEarned = value; }

        public double OverallRating => Players.Count == 0 ? 0 : Math.Round(Players.Average(x => x.Rating),2);

        public IReadOnlyCollection<IPlayer> Players =>this.players.ToList<IPlayer>().AsReadOnly();
        public void SignContract(IPlayer player)
        {
            this.players.Add(player);
        }
        public void Win()
        {
            PointsEarned += INCREASES_WIN_POINTS;
            foreach (var player in Players)
            {
                player.IncreaseRating();
            }
        }

        public void Draw()
        {
            PointsEarned += INCREASES_DRAW_POINTS;
            var goalkeeper = this.players.FirstOrDefault(x => x.GetType().Name == nameof(Goalkeeper));
            
            goalkeeper.IncreaseRating();
        }

        public void Lose()
        {
            foreach (var player in Players)
            {
                player.DecreaseRating();
            }
        }

        public override string ToString()
        {
            string names = string.Empty;
            if(Players.Count > 0)
            {
                List <string> strings = new List<string>();
                foreach (var player in Players)
                {
                    strings.Add(player.Name);
                }
                names=string.Join(", ",strings);
            }
            else
            {
                name = "none";
            }
            StringBuilder sb=new StringBuilder();

            sb.AppendLine($"Team: {Name} Points: {PointsEarned}")
                .AppendLine($"--Overall rating: {OverallRating}")
            .AppendLine($"--Players: {names}");

            return sb.ToString().TrimEnd();
        }
    }
}
