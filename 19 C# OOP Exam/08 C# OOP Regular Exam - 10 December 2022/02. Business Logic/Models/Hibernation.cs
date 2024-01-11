namespace ChristmasPastryShop.Models
{
    public class Hibernation : Cocktail
    {
        private const double PRICE = 10.50;
        public Hibernation(string cocktailName, string size) 
            : base(cocktailName, size, PRICE)
        {
        }
    }
}
