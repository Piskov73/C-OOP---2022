using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        //•	name: string
        //•	firstTeam: List<Person>
        //•	reserveTeam: List<Person>
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();

        }

        public IReadOnlyCollection<Person> FirstTeam { get { return firstTeam.AsReadOnly(); } }
        public IReadOnlyCollection<Person> ReserveTeam { get { return reserveTeam.AsReadOnly(); } }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
        public override string ToString()
        {
            // First team has 4 players.
            //Reserve team has 1 players.
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First team has {this.firstTeam.Count} players.");
            sb.Append($"Reserve team has {this.reserveTeam.Count} players.");
            return sb.ToString();
        }

    }
}
