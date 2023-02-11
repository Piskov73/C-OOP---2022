

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        
        private const double COFEE_MILLILITERS = 50;
        private const decimal COFEE_PRICE = 3.50m;

        public Coffee(string name, decimal price, double milliliters,double caffeine) : base(name, price, milliliters)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
        public override double Milliliters => COFEE_MILLILITERS;
        public override decimal Price => COFEE_PRICE;
    }
}
