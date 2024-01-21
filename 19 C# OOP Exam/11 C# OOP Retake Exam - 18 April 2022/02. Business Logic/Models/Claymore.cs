namespace Heroes.Models
{
    public class Claymore : Weapon
    {
        private const int DAMAGE = 20;
        public Claymore(string name, int durability)
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (base.Durability == 0)
            {
                return 0;
            }
            base.Durability--;

            return DAMAGE;
        }
    }
}
