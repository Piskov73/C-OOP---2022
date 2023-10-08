namespace Handball.Models
{
    public class ForwardWing : Player
    {
        private const double RETING_VALUE = 5.5;
        private double INCREASE_VALUE = 1.25;
        private double DECREASE_VALUE = 0.75;
        public ForwardWing(string name) : base(name, RETING_VALUE)
        {
        }

        public override void DecreaseRating()
        {
            base.Rating -= DECREASE_VALUE;
            if (base.Rating < 1) base.Rating = 1;
        }

        public override void IncreaseRating()
        {
            base.Rating += INCREASE_VALUE;
            if (base.Rating > 10) base.Rating = 10;
        }
    }
}
