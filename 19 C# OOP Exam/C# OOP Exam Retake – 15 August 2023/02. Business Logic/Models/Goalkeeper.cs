namespace Handball.Models
{
    public class Goalkeeper : Player
    {
        private const double RETING_VALUE = 2.5;
        private double INCREASE_VALUE = 0.75;
        private double DECREASE_VALUE = 1.25;


        public Goalkeeper(string name) : base(name,RETING_VALUE )
        {
        }

        public override void DecreaseRating()
        {
            base.Rating -= DECREASE_VALUE;
            if(base.Rating<1) base.Rating= 1;
        }

        public override void IncreaseRating()
        {
            base.Rating += INCREASE_VALUE;
            if(base.Rating>10) base.Rating= 10;
        }
    }
}
