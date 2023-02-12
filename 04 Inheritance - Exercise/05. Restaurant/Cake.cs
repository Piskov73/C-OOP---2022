namespace Restaurant
{
    public class Cake : Dessert
    {
     
        private const double GRAMS = 250;
        private const double CALORIES = 1000;
        private const decimal CACE_PRICE = 5;
        public Cake(string name) : base(name, CACE_PRICE, GRAMS, CALORIES)
        {
        }
    }
}
