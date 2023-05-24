namespace BirthdayCelebrations.Models
{
    using Interface;
    public class Pet : IPet
    {
        public Pet(string name, string brithdate)
        {
            this.Name = name;
            this.Birthdate = brithdate;
        }
        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
