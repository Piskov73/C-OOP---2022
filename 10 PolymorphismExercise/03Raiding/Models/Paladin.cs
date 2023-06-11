namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        //Paladin
        private const int POWER_PALADIN = 100;
        public Paladin(string name)
            : base(name, POWER_PALADIN)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
