namespace Handball.Models
{
    using System;
    using System.Text;

    using Contracts;
    using Utilities.Messages;

    public abstract class Player : IPlayer
    {
        private string name;
        private double rating;
        private string team;


        protected Player(string name, double rating)
        {
            this.Name = name;
            this.Rating = rating;
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
        public double Rating
        {
            get { return rating; }
            protected set
            {
                rating = value;
            }
        }

        public string Team
        {
            get { return team; }
            private set { team = value; }
        }

        public abstract void DecreaseRating();

        public abstract void IncreaseRating();


        public void JoinTeam(string name)
        {
            this.Team = name;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {Name}")
                .AppendLine($"--Rating: {Rating}");
            return sb.ToString().TrimEnd();
        }
    }
}
