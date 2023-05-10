namespace FootballTeamGenerator
{
    using System;
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Stats(int endurance,int sprint,int dribble,int passing , int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                if(ChekStat(value))
                    throw new ArgumentException(string.Format(MessageExceptions.INVALID_STATS_RANGE,nameof(this.Endurance)));
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;
            private set
            {
                if (ChekStat(value))
                    throw new ArgumentException(string.Format(MessageExceptions.INVALID_STATS_RANGE, nameof(this.Sprint)));
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            private set
            {
                if (ChekStat(value))
                    throw new ArgumentException(string.Format(MessageExceptions.INVALID_STATS_RANGE, nameof(this.Dribble)));
                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            private set
            {
                if (ChekStat(value))
                    throw new ArgumentException(string.Format(MessageExceptions.INVALID_STATS_RANGE, nameof(this.Passing)));
                this.passing = value;
            }
        }
        public int Shooting
        {
            get =>this. shooting;
            private set
            {
                if (ChekStat(value))
                    throw new ArgumentException(string.Format(MessageExceptions.INVALID_STATS_RANGE, nameof(this.Shooting)));
                this.shooting=value;
            }
        }
        public double SkillLevel => (Endurance + Sprint + Dribble + Passing+Shooting) / 5.0;
        private bool ChekStat(int valueStats)
        {
            if (valueStats < 0 || valueStats > 100)
                return true;
            return false;
        }

    }
}
