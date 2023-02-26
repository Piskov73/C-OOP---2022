
using System;

namespace _05FootballTeamGenerator
{
    public class Stat
    {
        private const int STAT_MIN = 0;
        private const int STAT_MAX = 100;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Stat(int endurance, int sprint, int drobble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = drobble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        public int Endurance
        {
            get { return endurance; }
            private set
            {
                if (value < STAT_MIN || value > STAT_MAX)
                {
                    throw new ArgumentException(string.Format(MessageException.STATS_RANGE,nameof(this.Endurance)));
                }
                endurance = value;
            }
        }
        public int Sprint
        {
            get { return sprint; }
            private set
            {
                if (value < STAT_MIN || value > STAT_MAX)
                {
                    throw new ArgumentException(string.Format(MessageException.STATS_RANGE, nameof(this.Sprint)));
                }
                sprint = value;
            }
        }
        public int Dribble
        {
            get { return dribble; }
            private set
            {
                if (value < STAT_MIN || value > STAT_MAX)
                {
                    throw new ArgumentException(string.Format(MessageException.STATS_RANGE, nameof(this.Dribble)));
                }
                dribble = value;
            }
        }
        public int Passing
        {
            get { return passing; }
            private set
            {
                if (value < STAT_MIN || value > STAT_MAX)
                {
                    throw new ArgumentException(string.Format(MessageException.STATS_RANGE, nameof(this.Passing)));
                }
                passing = value;
            }
        }
        public int Shooting
        {
            get { return shooting; }
            private set
            {
                if (value < STAT_MIN || value > STAT_MAX)
                {
                    throw new ArgumentException(string.Format(MessageException.STATS_RANGE, nameof(this.Shooting)));
                }
                shooting = value;
            }
        }
    }
}
