namespace Handball.Core
{
    using Handball.Core.Contracts;
    using Handball.Models;
    using Handball.Repositories;
    using Handball.Utilities.Messages;
    using System;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

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
            var team = this.teams.GetModel(name);

            if (team != null)
                return string.Format(OutputMessages.TeamAlreadyExists, name, this.teams.GetType().Name);

            team = new Team(name);

            this.teams.AddModel(team);

            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, this.teams.GetType().Name);
        }

        public string NewPlayer(string typeName, string name)
        {
            var player = this.players.GetModel(name);

            if (player != null)
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, this.players.GetType().Name, player.GetType().Name);

            if (typeName == nameof(Goalkeeper))
            {
                player = new Goalkeeper(name);
            }
            else if (typeName == nameof(ForwardWing))
            {
                player = new ForwardWing(name);
            }
            else if (typeName == nameof(CenterBack))
            {
                player = new CenterBack(name);
            }
            else
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            this.players.AddModel(player);

            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }
        public string NewContract(string playerName, string teamName)
        {
            var player = this.players.GetModel(playerName);
            if (player == null)
                return string.Format(OutputMessages.PlayerNotExisting, playerName, nameof(PlayerRepository));

            var team = this.teams.GetModel(teamName);

            if (team == null)
                return string.Format(OutputMessages.TeamNotExisting, teamName, nameof(TeamRepository));

            if (player.Team != null)
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);

            player.JoinTeam(teamName);

            team.SignContract(player);

            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            var firstTeam = this.teams.GetModel(firstTeamName);

            var secondTeam = this.teams.GetModel(secondTeamName);

            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, firstTeamName, secondTeamName);

            }
            else if (firstTeam.OverallRating < secondTeam.OverallRating)
            {
                firstTeam.Lose();
                secondTeam.Win();
                return string.Format(OutputMessages.GameHasWinner, secondTeamName, firstTeamName);
            }

            firstTeam.Draw();
            secondTeam.Draw();

            return string.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);
        }
        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new StringBuilder();
            var team = this.teams.GetModel(teamName);

            sb.AppendLine($"***{teamName}***");
            foreach (var player in team.Players.OrderByDescending(p=>p.Rating).ThenBy(p=>p.Name)) 
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string LeagueStandings()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***League Standings***");
            foreach (var item in this.teams.Models.OrderByDescending(t=>t.PointsEarned)
                .ThenByDescending(t=>t.OverallRating).ThenBy(t=>t.Name))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }


    }
}
