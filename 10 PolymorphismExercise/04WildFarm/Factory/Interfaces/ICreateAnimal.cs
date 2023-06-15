namespace WildFarm.Factory.Interfaces
{
    using Models.Interfaces;
    public interface ICreateAnimal
    {
        IAnimal GetAnima(string text);
    }
}
