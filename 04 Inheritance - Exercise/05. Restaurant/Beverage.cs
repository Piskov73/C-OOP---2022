namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price,double millilitres) : base(name, price)
        {
            Milliliters = millilitres;
        }
        
        public double Milliliters { get; set; }
    }
}
