namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var teams = new HashSet<Team>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                    string comand = tokens[0];
                    string nameTeam = tokens[1];
                    if (comand == "Team")
                    {
                        var team = new Team(nameTeam);
                        teams.Add(team);
                        continue;
                    }
                    var filterTeam = teams.FirstOrDefault(t => t.Name == nameTeam);
                    if (filterTeam == null)
                        throw new ArgumentException(string.Format(MessageExceptions.NO_TEAM, nameTeam));
                    if (comand == "Add")
                    {
                        //Add;Arsenal;Kieran_Gibbs;75;85;84;92;67
                        string namePlayer = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);
                        var stats = new Stats(endurance, sprint, dribble, passing, shooting);
                        filterTeam.Add(new Player(namePlayer, stats));
                    }
                    else if (comand == "Remove")
                    {
                        //Remove;Arsenal;Aaron_Ramsey
                        string namePlayer = tokens[2];
                        filterTeam.Remove(namePlayer);
                    }
                    else if (comand == "Rating")
                    {
                        Console.WriteLine(filterTeam);
                    }
                    else throw new ArgumentException("Invalid command!");
                }
                catch (ArgumentException axc)
                {
                    Console.WriteLine(axc.Message);

                }
               

            }


        }
    }
}
