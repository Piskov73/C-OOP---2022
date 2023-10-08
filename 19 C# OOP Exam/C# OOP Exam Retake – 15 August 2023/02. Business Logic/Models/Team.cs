using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handball.Models
{
    public class Team : ITeam
    {

        private string name;
        private int pointsEarned;
        private List<IPlayer> players;
        public Team(string name)
        {
            Name = name;
            pointsEarned=0;
            players = new List<IPlayer>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.TeamNameNull));

                name = value;
            }
        }

        public int PointsEarned =>pointsEarned;

        public double OverallRating => this.players.Count == 0 ? 0 : Math.Round(this.players.Average(p => p.Rating),2);

        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        public void SignContract(IPlayer player)
        {
            this.players.Add(player);
        }

        public void Win()
        {
            this.pointsEarned += 3;
            foreach (var player in this.players)
            {
                player.IncreaseRating();
            }
        }
        public void Lose()
        {
            foreach (var player in this.players)
            {
                player.DecreaseRating();
            }
        }
        public void Draw()
        {
            this.pointsEarned += 1;
            var goalkeeper=this.players.First(p=>p.GetType().Name ==nameof(Goalkeeper));
            goalkeeper.IncreaseRating();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}")
                .AppendLine($"--Overall rating: {OverallRating}")
                .Append($"--Players: ");
            var playersName=this.Players.Select(p=> p.Name).ToList();
            if(playersName.Count== 0 )
            {
                sb.Append("none");
            }
            else
            {
                sb.Append(string.Join(", ", playersName));

            }

            return sb.ToString().TrimEnd();
        }


    }
}
