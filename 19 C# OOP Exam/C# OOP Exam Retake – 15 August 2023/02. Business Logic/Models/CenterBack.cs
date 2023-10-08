namespace Handball.Models
{
    public class CenterBack : Player
    {
        private const double RETING_VALUE = 4;
        private double INCREASE_VALUE = 1;
        private double DECREASE_VALUE = 1;
        public CenterBack(string name) : base(name, RETING_VALUE)
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
