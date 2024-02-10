namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int FISH_SIZE = 5;
        private const int INCREASES = 2;
        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            base.Size = FISH_SIZE;
        }

        public override void Eat()
        {
            base.Size += INCREASES;
        }
    }
}
