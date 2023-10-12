using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private List<ILoan> loanList;

        public LoanRepository()
        {
            this.loanList = new List<ILoan>();
        }
        public IReadOnlyCollection<ILoan> Models => this.loanList.AsReadOnly();

        public void AddModel(ILoan model)
        {
            this.loanList.Add(model);
        }

        public ILoan FirstModel(string name)
        {
        return this.loanList.FirstOrDefault(l=>l.GetType().Name == name);
        }

        public bool RemoveModel(ILoan model)
        {
           return this.RemoveModel(model);
        }
    }
}
