namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        //        •	double CoffeeMilliliters = 50
        //•	decimal CoffeePrice = 3.50
        private const double COFFEE_MILLILITRES = 50;
        private const decimal COFFEE_PRICE = 3.50m;
        public Coffee(string name,  double caffeine) : base(name, COFFEE_PRICE, COFFEE_MILLILITRES)
        {
            Caffeine = caffeine;
        }
        public double Caffeine { get; set; }
    }
}
