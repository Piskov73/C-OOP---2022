﻿namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Interface;
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly ICollection<IPrivate> privates;
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, ICollection<IPrivate> privates) : base(id, firstName, lastName, salary)
        {
            this.privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates => (IReadOnlyCollection<Private>)this.privates;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine("Privates:");
            foreach (IPrivate priv in privates)
            {
                sb.AppendLine($"  {priv}");
            }


            return sb.ToString().TrimEnd();
        }
    }
}
