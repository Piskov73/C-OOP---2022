

namespace Restaurant
{
    public class Cake : Dessert
    {
   
        private const double GRAMS_CAKE = 250;
     
        private const double CALORIES_CAKE = 1000;
        
        private const decimal CAKE_PRICE = 5m;


        public Cake(string name, decimal price, double grams, double calories) : base(name, price, grams, calories)
        {
        }
        public override double Grams => GRAMS_CAKE;
        public override double Calories => CALORIES_CAKE;
        public override decimal Price => CAKE_PRICE;
    }
}
