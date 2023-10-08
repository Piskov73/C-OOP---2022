using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Text;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string name;
        private double rating;
        private string team;

        public Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
            Team = null;
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PlayerNameNull));
                }
                name = value;
            }
        }

        public double Rating { get => rating; protected set => rating = value; }

        public string Team { get => team; private set => team = value; }

        public void JoinTeam(string name)
        {
            this.Team = name;
        }
        public abstract void DecreaseRating();


        public abstract void IncreaseRating();

        public override string ToString()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {Name}")
                .AppendLine($"--Rating: {Rating}");

            return sb.ToString().TrimEnd();
        }
    }
}
