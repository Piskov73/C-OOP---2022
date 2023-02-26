using System;

namespace _05FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private Stat stats;

        public Player(string name, Stat stat)
        {
            this.Name = name;
            this.Stats = stat;

        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(MessageException.NAME_NULL_EMPTY));
                }
                name = value;
            }
        }
        public Stat Stats
        {
            get { return stats; ; }
            private set { stats = value; }
        }
        internal double SkillLevel => 1.0 * (Stats.Endurance+Stats.Sprint+Stats.Dribble+Stats.Passing+Stats.Shooting)/5;
    }
}
