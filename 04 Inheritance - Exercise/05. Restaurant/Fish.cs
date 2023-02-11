

namespace Restaurant
{
    public class Fish : MainDish
    {
       
        private const double FISH_GRAMS = 22;
        public Fish(string name, decimal price, double grams) : base(name, price, grams)
        {
        }
        public override double Grams => FISH_GRAMS;
    }
}
