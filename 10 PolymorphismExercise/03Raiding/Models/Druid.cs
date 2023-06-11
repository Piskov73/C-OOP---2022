namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        //Druid 
        private const int POWER_DRUID = 80;

        public Druid(string name)
            : base(name, POWER_DRUID)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
