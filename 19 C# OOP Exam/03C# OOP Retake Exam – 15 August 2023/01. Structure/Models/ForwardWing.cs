namespace Handball.Models
{
    public class ForwardWing : Player
    {
        private const double RATING = 5.5;
        private const double INCREAS_RATING = 1.25;
        private const double DECREASE_RATING = 0.75;
        public ForwardWing(string name) 
            : base(name, RATING)
        {
        }

        public override void DecreaseRating()
        {
            base.Rating -= DECREASE_RATING;
        }

        public override void IncreaseRating()
        {
            base.Rating += INCREAS_RATING;
        }
    }
}
