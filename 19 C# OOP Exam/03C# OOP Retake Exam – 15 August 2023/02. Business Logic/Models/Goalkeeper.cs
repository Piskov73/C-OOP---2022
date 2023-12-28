namespace Handball.Models
{
    public class Goalkeeper : Player
    {
        private const double RATING = 2.5;
        private const double INCREAS_RATING = 0.75;
        private const double DECREASE_RATING= 1.25;
        //DecreaseRating
        public Goalkeeper(string name)
            : base(name, RATING)
        {
        }

        public override void DecreaseRating()
        {
            base.Rating -= DECREASE_RATING;
        }

        public override void IncreaseRating()
        {
           base.Rating+= INCREAS_RATING;
        }
    }
}
