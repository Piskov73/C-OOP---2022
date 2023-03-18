namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using MilitaryElite.Models.Enums;
    using MilitaryElite.Models.Interfaces;
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly ICollection<IMissions> missions;
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps,ICollection<IMissions> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions=missions;
        }

        public IReadOnlyCollection<IMissions> Missions => (IReadOnlyCollection<IMissions>)this.missions;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            foreach(var mission in missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }
            return sb.ToString().TrimEnd();

        }
    }
}
