namespace WildFarm.Factory.Interfaces
{
    using Models.Interfaces;
    public interface ICreateFood
    {
        IFood GetFood(string type, int quantity);
    }
}
