namespace Restaurant
{
    public class Fish : MainDish
    {
        //•	Grams = 22
        private const double GRAMS = 22;
        public Fish(string name, decimal price) : base(name, price, GRAMS)
        {
        }
    }
}
