namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        //Rogue 
        private const int POWER_ROGUE = 80;
        public Rogue(string name)
            : base(name, POWER_ROGUE)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
