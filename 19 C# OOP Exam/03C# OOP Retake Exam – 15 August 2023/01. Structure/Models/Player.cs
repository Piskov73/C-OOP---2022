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
        public Player(string name, double rating) 
        { 
            Name=name;

        }
        public string Name
        {
            get => name;
            private set
            {
                if(string.IsNullOrWhiteSpace(value)) 
                    throw new ArgumentException(string.Format(ExceptionMessages.PlayerNameNull));

                name = value;
            }
        }

        public double Rating
        { 
            get => rating; 
            protected set
            {
                if (value > 10)
                    value = 10;
                else if (value < 1)
                    value = 1;

                rating = value;

            }
        }

        public string Team => this.team;

        public abstract void DecreaseRating();
       

        public abstract void IncreaseRating();
     

        public void JoinTeam(string name)
        {
            this.team = name;
        }

        public override string ToString()
        {
           StringBuilder sb=new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {Name}")
                .AppendLine($"--Rating: {Rating}");
            return sb.ToString().TrimEnd();
        }
    }
}
