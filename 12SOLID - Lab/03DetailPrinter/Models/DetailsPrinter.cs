namespace DetailPrinter.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    public class DetailsPrinter
    {
        private IList<IEemployee> employees;
        public DetailsPrinter(IList<IEemployee> employees)
        {
            this.employees = employees;
        }
        public string PrintDetails()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine(employee.Print());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
