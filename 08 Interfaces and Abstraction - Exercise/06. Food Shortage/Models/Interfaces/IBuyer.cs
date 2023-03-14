namespace _06FoodShortage.Models.Interfaces
{
    public interface IBuyer
    {
        string Name { get; }
        int Food { get; }
        void BuyFood();
    }
}
