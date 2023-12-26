namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        private const int oxygenLevel = 120;
        private const double decreaseOxygenLevel = 0.6;
        public FreeDiver(string name) 
            : base(name, oxygenLevel)
        {
        }

        public override void Miss(int timeToCatch)
        {
            base.OxygenLevel-=(int)(Math.Round(decreaseOxygenLevel*timeToCatch));
        }

        public override void RenewOxy()
        {
            base.OxygenLevel=oxygenLevel;
        }
    }
}
