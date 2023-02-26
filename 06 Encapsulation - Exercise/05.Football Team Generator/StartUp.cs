using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace _05FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
       
            List<Team> teams = new List<Team>();
            string comand = Console.ReadLine();
            while (comand != "END")
            {
                try
                {
                    string[] token = comand.Split(';');
                    switch (token[0])
                    {
                        case "Team":
                            var newTeam = new Team(token[1]);
                            teams.Add(newTeam);
                            break;
                        case "Add":
                            Team addToTeam = ReturnTeam(teams, token[1]);
                            var player = new Player(token[2], new Stat(int.Parse(token[3]),
                                int.Parse(token[4]), int.Parse(token[5]),
                                int.Parse(token[6]), int.Parse(token[7])));
                            addToTeam.AddPlayer(player);
                            break;
                        case "Remove":
                            var remuveToTeam = ReturnTeam(teams, token[1]);
                            remuveToTeam.RemovePlayer(token[2]);

                            break;
                        case "Rating":
                            var ratingToPlaer = ReturnTeam(teams, token[1]);
                            Console.WriteLine(ratingToPlaer);
                            break;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                comand = Console.ReadLine();
            }

        }

        static Team ReturnTeam(List<Team> teams, string nameTeam)
        {
            var team = teams.FirstOrDefault(t => t.Name == nameTeam);
            if (team == null)
            {
                throw new AggregateException(string.Format(MessageException.MISSING_TEAM, nameTeam));

            }
            return team;
        }
    }
}
