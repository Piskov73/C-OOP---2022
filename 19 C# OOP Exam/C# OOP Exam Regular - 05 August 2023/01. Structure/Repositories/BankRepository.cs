using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private List<IBank> banks;
        public BankRepository()
        { 
            this.banks=new List<IBank>();
        }
        public IReadOnlyCollection<IBank> Models => this.banks.AsReadOnly();

        public void AddModel(IBank model)
        {
            this.banks.Add(model);
        }

        public IBank FirstModel(string name)
        {
            return this.banks.FirstOrDefault(b=>b.Name==name);
        }

        public bool RemoveModel(IBank model)
        {
            return this.banks.Remove(model);
        }
    }
}
