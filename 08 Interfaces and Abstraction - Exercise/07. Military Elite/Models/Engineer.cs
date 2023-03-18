namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using MilitaryElite.Models.Enums;
    using MilitaryElite.Models.Interfaces;
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly ICollection<IRepair> repairs;
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps,ICollection<IRepair > repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>)this.repairs;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine("Repairs:");
            foreach (var pair in this.repairs)
            {
                sb.AppendLine($"  {pair.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
