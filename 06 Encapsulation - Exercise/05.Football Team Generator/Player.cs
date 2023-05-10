namespace FootballTeamGenerator
{
    using System;

    public class Player
    {
        private string name;
        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
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
        public Stats Stats { get; }
    }
}
