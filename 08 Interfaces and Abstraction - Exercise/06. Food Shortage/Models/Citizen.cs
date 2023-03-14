namespace _06FoodShortage.Models
{
    using Interfaces;

    public class Citizen : ICitizen,IAge,IBuyer
    {
        public Citizen(string name,int age,string id,string brithdate) 
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Brithdate= brithdate;
        }
        public string Name { get;private set; }

        public int Age { get;private set; }

        public string Id { get;private set; }

        public string Brithdate { get;private set; }

        public int Food { get;private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
