namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double DEFAULT_CAKE_GRAMS = 250;
        private const double DEFAULT_CAKE_CALORIES = 1000;
        private const decimal DEFAULT_CAKE_PRICE = 5M;



        public Cake(string name) : base(name, DEFAULT_CAKE_PRICE, DEFAULT_CAKE_GRAMS, DEFAULT_CAKE_CALORIES)
        {
        }

    }
}
