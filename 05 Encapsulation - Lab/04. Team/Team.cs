namespace PersonsInfo
{
    using System.Collections.Generic;

    public class Team
    {
       
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public ICollection<Person> FirstTeam
        {
            get { return firstTeam.AsReadOnly(); }
            
        }
        public ICollection<Person> ReserveTeam
        {
            get { return reserveTeam.AsReadOnly(); }
        }

        public void 	AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }

        }

    }
}
