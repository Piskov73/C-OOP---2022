namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int FISH_SIZE= 3;
        private const int INCREASES = 3;
        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            base.Size = FISH_SIZE;
        }

       

        public override void Eat()
        {
            base.Size+=INCREASES;
        }
    }
}
