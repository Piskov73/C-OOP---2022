﻿namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Enum;
    using Interface;
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly ICollection<IMission> missions;
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps, ICollection<IMission> missions)
            : base(id, firstName, lastName, salary, corps)

        {
            this.missions = missions;
        }

        public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>)this.missions;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine("Missions:");

            foreach (IMission mission in missions)
                sb.AppendLine(mission.ToString());

            return sb.ToString().TrimEnd();
        }

    }
}
