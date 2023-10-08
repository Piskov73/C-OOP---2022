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
        private string  name;
        private int pointsEarned;
        
        private List<IPlayer> players;

        public Team(string name)
        {
            this.Name = name;
            this.PointsEarned = 0;
            this.players = new List<IPlayer>();
        }


        public string  Name
        {
            get { return name; }
           private set 
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.TeamNameNull));
                }
                name = value;
            }
        }

        public int PointsEarned
        {
            get { return pointsEarned; }
           private set { pointsEarned = value; }
        }

        public double OverallRating => this.Players.Count == 0 ? 0 : Math.Round(this.Players.Average(p => p.Rating));
     


        public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();
        public void SignContract(IPlayer player)
        {
            this.players.Add(player);
        }
        public void Win()
        {
            this.PointsEarned += 3;

            foreach (var player in players)
            {
                player.IncreaseRating();
            }
        }
        public void Lose()
        {
            foreach (var player in players)
            {
                player.DecreaseRating();
            }
        }
        public void Draw()
        {
            this.PointsEarned += 1;

            var player = this.players.First(p => p.GetType().Name == "Goalkeeper");
            player.IncreaseRating();
        }
        public override string ToString()
        {
            StringBuilder sb=new StringBuilder();

            sb.AppendLine($"Team: {Name} Points: {PointsEarned}")
                .AppendLine($"--Overall rating: {OverallRating}")
                .Append("--Players: ");
            if (players.Any())
            {
                var names =players.Select(p=>p.Name);
                sb.Append(string.Join(", ", names));
            }
            else
            {
                sb.Append("none");
            }
            return sb.ToString().TrimEnd();
        }




    }
}
