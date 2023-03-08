namespace BirthdayCelebrations.Metods
{
    using Interfaces;

    public class Citizens : ICitizens ,IPersonallyID, IBirthday
    {
        public Citizens(string name,int age, string id, string birthdey)
        { 
            this.Name = name;
            this.Age = age;
            this.ID= id;
            this.Birthday= birthdey;
        }
        public string Name { get;private set; }

        public int Age { get; private set; }

        public string ID { get; private set; }

        public string Birthday { get; private set; }
    }
}
