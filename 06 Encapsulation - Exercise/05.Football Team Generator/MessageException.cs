namespace _05FootballTeamGenerator
{
    public static class MessageException
    {
        public const string STATS_RANGE = "{0} should be between 0 and 100.";
        public const string NAME_NULL_EMPTY = "A name should not be empty.";
        public const string MISSING_PLAYER = "Player {0} is not in {1} team.";
        public const string MISSING_TEAM = "Team {0} does not exist.";
    }
}
