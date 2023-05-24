namespace BirthdayCelebrations.Models
{
    using Interface;
    public class Citizen : ICitizen
    {
        public Citizen(string name, int age, string id, string brithdate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.Birthdate = brithdate;
        }
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string ID { get; private set; }

        public string Birthdate { get; private set; }
    }
}
