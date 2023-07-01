namespace DetailPrinter.Models
{
    using System.Collections.Generic;
    using System.Text;
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new HashSet<string>(documents);
        }
        public IReadOnlyCollection<string> Documents { get; private set; }
        public override string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Print());
            foreach (string document in this.Documents)
            {
                sb.AppendLine(document);
            }

            return sb.ToString().TrimEnd();

        }
    }
}
