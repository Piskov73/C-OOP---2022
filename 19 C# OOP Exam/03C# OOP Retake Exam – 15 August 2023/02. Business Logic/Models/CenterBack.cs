namespace Handball.Models
{
    public class CenterBack : Player
    {
        private const double RATING = 4;
        private const double INCREAS_RATING = 1;
        private const double DECREASE_RATING = 1;

        public CenterBack(string name)
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
