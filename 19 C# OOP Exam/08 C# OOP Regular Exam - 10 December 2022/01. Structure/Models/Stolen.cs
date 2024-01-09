namespace ChristmasPastryShop.Models
{
    public class Stolen : Delicacy
    {
        private const double PRICE = 3.50;
        public Stolen(string delicacyName)
            : base(delicacyName, PRICE)
        {
        }
    }
}
