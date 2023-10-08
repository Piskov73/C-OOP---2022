using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Handball.Core
{
    public class Controller : IController
    {
        private PlayerRepository players;
        private TeamRepository teams;

        public Controller()
        {
            this.players = new PlayerRepository();
            this.teams = new TeamRepository();
        }
        public string NewTeam(string name)
        {
            if (this.teams.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, nameof(TeamRepository));
            }

            this.teams.AddModel(new Team(name));

            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, nameof(TeamRepository));

        }

        public string NewPlayer(string typeName, string name)
        {
            //Goalkeeper, CenterBack or ForwardWing), 

            if (typeName != nameof(Goalkeeper) && typeName != nameof(CenterBack) && typeName != nameof(ForwardWing))
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }


            if (this.players.ExistsModel(name))
            {
                var player = this.players.GetModel(name);

                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, nameof(PlayerRepository), player.GetType().Name);
            }

            IPlayer playerADD;
            if (typeName == nameof(Goalkeeper))
            {
                playerADD = new Goalkeeper(name);
            }
            else if (typeName == nameof(CenterBack))
            {
                playerADD=new CenterBack(name); 
            }
            else
            {
                playerADD=new ForwardWing(name);
            }

            this.players.AddModel(playerADD);

            return string.Format(OutputMessages.PlayerAddedSuccessfully,playerADD.Name);
        }

        public string NewContract(string playerName, string teamName)
        {
            if(!this.players.ExistsModel(playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting,playerName,nameof(PlayerRepository));
            }
            if (!this.teams.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, nameof(TeamRepository));
            }
            var player=this.players.GetModel(playerName);
            if(player.Team!=null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, player.Name,player.Team);
            }

            var team=this.teams.GetModel(teamName);

            player.JoinTeam(team.Name);

            team.SignContract(player);

            return string.Format(OutputMessages.SignContract, player.Name, player.Team);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            var firstTeam=this.teams.GetModel(firstTeamName);
            var secondTeam=this.teams.GetModel(secondTeamName);

            if(firstTeam.OverallRating!=secondTeam.OverallRating)
            {
                ITeam first;
                ITeam second;

                if (firstTeam.OverallRating > secondTeam.OverallRating)
                {
                    first=firstTeam;
                    second=secondTeam;
                }
                else
                {
                    first = secondTeam;
                    second=firstTeam;
                }
                first.Win();
                second.Lose();

                return string.Format(OutputMessages.GameHasWinner, first.Name,second.Name);
            }
            else
            {
                firstTeam.Draw();
                secondTeam.Draw();

                return string.Format(OutputMessages.GameIsDraw,firstTeam.Name,secondTeam.Name);
            }

            
        }
        public string PlayerStatistics(string teamName)
        {
            var team=this.teams.GetModel(teamName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***{teamName}***");
            foreach (var player in team.Players.OrderByDescending(p=>p.Rating).ThenBy(p=>p.Name))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string LeagueStandings()
        {
            var teamsStandings = this.teams.Models.OrderByDescending(t=>t.PointsEarned)
                .ThenByDescending(t=>t.OverallRating).ThenBy(t=>t.Name);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***League Standings***");
             foreach(var team in teamsStandings)
            {
                sb.AppendLine(team.ToString());
            }


            return sb.ToString().TrimEnd();
        }
    }
}
