using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private List<ILoan> models;
        public LoanRepository()
        { 
            this.models=new List<ILoan>();
        }
        public IReadOnlyCollection<ILoan> Models => this.models.AsReadOnly();

        public void AddModel(ILoan model)
        {
            this.models.Add(model);
        }

        public ILoan FirstModel(string name)
        {
            return this.models.FirstOrDefault(n=>n.GetType().Name==name);
        }

        public bool RemoveModel(ILoan model)
        {
            return this.models.Remove(model);
        }
    }
}
