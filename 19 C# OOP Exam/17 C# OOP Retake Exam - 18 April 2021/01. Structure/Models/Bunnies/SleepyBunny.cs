namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int ENERGY = 50;
        public SleepyBunny(string name)
            : base(name, ENERGY)
        {
        }

        public override void Work()
        {
            base.Energy -= 15;
        }
    }
}
